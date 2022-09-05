using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Base;
using ShopStoreCore.System.Provicy;
using StoreShare.Dto.Operation;

namespace ShopStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IBase<SystemOperation> _baseRep;
        private readonly IMapper _mapper;

        public OperationController(IBase<SystemOperation> baseRep,IMapper mapper)
        {
            _baseRep = baseRep;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ShowOprs()
        {
            var opers = _baseRep.GetAll(null).ToList();

            var res = _mapper.Map<List<OprsDto>>(opers);

            return new JsonResult(res);
        }
        [HttpPost]
        public IActionResult CreateOpr(OprsAddDto oprsAddDto)
        {
            var oper = _mapper.Map<SystemOperation>(oprsAddDto);
            _baseRep.Insert(oper); 
            return new JsonResult(oper);
        }
    }
}
