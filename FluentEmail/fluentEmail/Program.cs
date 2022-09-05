
using fluentEmail;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Net;
using System.Net.Mail;

#region 
//SmtpClient smtp = new SmtpClient()
//{
//    Host = "smtp.qq.com",

//    EnableSsl=true,
//    UseDefaultCredentials = false,
//    DeliveryMethod = SmtpDeliveryMethod.Network,
//    Credentials = new NetworkCredential("1824782123@qq.com", "sfyfpxyvxcazbbbd")

//};

////设置默认发送信息
//Email.DefaultSender = new SmtpSender(smtp);
//var email = Email
//    //发送人
//    .From("1824782123@qq.com")
//    //收件人
//    .To("2446216755@qq.com")
//    //抄送人
//    .CC("2446216755@qq.com")
//    //邮件标题
//    .Subject("邮件标题")
//    //邮件内容
//    .Body("邮件内容");
////依据发送结果判断是否发送成功
//var result = email.Send();
////或使用异步的方式发送
////await email.SendAsync();
//if (result.Successful)
//{
//    //发送成功逻辑
//}
//else
//{
//    //发送失败可以通过result.ErrorMessages查看失败原因
//}
#endregion

MyFluentEmail myFluent = new MyFluentEmail();
myFluent.FromEmail = "1824782123@qq.com";
myFluent.ToEmail = "2446216755@qq.com";
myFluent.SendMessage("这是标题", "<a href='https://localhost:7163/home/index'>请确认您的code</a>");