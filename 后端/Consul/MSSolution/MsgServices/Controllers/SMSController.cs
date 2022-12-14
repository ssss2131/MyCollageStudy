using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsgServices.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class SMSController : ControllerBase
    {
        //发请求，报文体为｛phoneNum:"110",msg:"aaaaaaaaaaaaa"},n
        [HttpPost(nameof(Send_MI))]
        public void Send_MI(dynamic model)
        {
            Console.WriteLine($"通过小米短信接口向{model.PhoneNum}发送短信{model.Msg}");
        }
        [HttpPost(nameof(Send_LX))]
        public void Send_LX(SendSMSRequest model)
        {
            Console.WriteLine($"通过联想短信接口向{model.PhoneNum}发送短信{model.Msg}");
        }
        [HttpPost(nameof(Send_HW))]
        public void Send_HW(SendSMSRequest model)
        {
            Console.WriteLine($"通过华为短信接口向{model.PhoneNum}发送短信{model. Msg}");
        }
    }
    public class SendSMSRequest {
        public string PhoneNum { get; set; }
        public string Msg { get; set; }
    }

}
