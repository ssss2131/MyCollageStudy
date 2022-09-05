 
using Microsoft.AspNetCore.Mvc;

namespace TableDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private List<MyGood> m_Goods;
        public GoodsController()
        {
             this.m_Goods = new List<MyGood> {
                new MyGood{ id=1,goods_name="商品1",goods_price=12.56M,tages=new string[]{ "日常","生活"},inputVisable=false,inputValue="" },
                new MyGood{ id=2,goods_name="商品2",goods_price=12.56M,tages=new string[]{ "日常","生活"},inputVisable=false,inputValue="" },
                new MyGood{ id=3,goods_name="商品3",goods_price=12.56M,tages=new string[]{ "日常","生活"},inputVisable=false,inputValue="" },
                new MyGood{ id=4,goods_name="商品4",goods_price=12.56M,tages=new string[]{ "日常","生活"},inputVisable=false,inputValue=""},
                new MyGood{ id=5,goods_name="商品5",goods_price=12.56M,tages=new string[]{ "日常","生活"},inputVisable=false,inputValue="" }
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetGoods()
        {
            var goodResult = new GoodResult(0, "请求成功")
            {
                Data = this.m_Goods
            };
            return new JsonResult(goodResult);
        }
    }
}
