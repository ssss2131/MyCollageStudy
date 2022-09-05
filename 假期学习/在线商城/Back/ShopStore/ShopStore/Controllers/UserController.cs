using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Base;
using ShopStore.tools;
using ShopStoreCore.System;
using StoreShare.Dto.User;
using System.Security.Cryptography;
using System.Text;

namespace ShopStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBase<SystemUser> _baseRep;
        private readonly IMapper _mapper;

        public UserController(IBase<SystemUser> baseRep,IMapper mapper)
        {
            _baseRep = baseRep;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ShowUsers()
        {
            var users = _baseRep.GetAll(null).ToList();
            var res =_mapper.Map<List<UsersDto>>(users);
            return new JsonResult(res);
        }
        [HttpPost]
        public IActionResult CreateUser([FromServices] MyMD5 myMD5,UserAddDto userAddDto)
        {
            if (string.IsNullOrEmpty(userAddDto.UserPassword))
            {
                return BadRequest();
            }
            var user = _mapper.Map<SystemUser>(userAddDto);
           
            user.UserPassword = myMD5.EncryptPasswordMD5(userAddDto.UserPassword);

            _baseRep.Insert(user);
            return new JsonResult(user);
        }
        
    
    }
}
