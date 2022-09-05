using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repository.Base;
using ShopStoreCore.System;
using StoreShare.Dto.Role;

namespace ShopStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PrivilegeController : ControllerBase
    {
        private readonly IBase<SystemRole> _baseRep;
        private readonly IMapper _mapper;

        public PrivilegeController(IBase<SystemRole> baseRep,IMapper mapper)
        {
            _baseRep = baseRep;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ShowRoles()
        {
            var roles = _baseRep.GetAll(null).ToList();
            
            return new JsonResult(_mapper.Map<List<RolesDto>>(roles));
        }
        [HttpPost]
        public IActionResult CreateRole(RoleAddDto roleAddDto)
        {
            if(!ModelState.IsValid)
            {
                return new JsonResult(ModelState);
            }
            var role = _mapper.Map<SystemRole>(roleAddDto);
            _baseRep.Insert(role);
            return new JsonResult(role);
        }
    }
}
