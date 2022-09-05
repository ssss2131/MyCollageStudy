using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Base;
using ShopStoreCore.System;
using StoreEfCore;
using StoreShare.Dto.Menu;

namespace ShopStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IBase<SystemMenu> _baseRep;
        private readonly IMapper _mapper;

        public MenuController(IBase<SystemMenu> baseRep,IMapper mapper)
        {
            _baseRep = baseRep;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetMenus()
        {
            Thread.Sleep(3000);
            return new JsonResult(_baseRep.GetAll(null).ToList());
        }
        [HttpPost]
        public IActionResult AddMenu(MenuAddDto menu)
        {
            var myMenu = _mapper.Map<SystemMenu>(menu);
            return new JsonResult(_baseRep.Insert(myMenu));             
        }
    
    }
}
