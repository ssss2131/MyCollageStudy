using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace fluentEmail
{
    //SmtpClient smtp = new SmtpClient()
    //{
    //    Host = "smtp.qq.com",

    //    EnableSsl = true,
    //    UseDefaultCredentials = false,
    //    DeliveryMethod = SmtpDeliveryMethod.Network,
    //    Credentials = new NetworkCredential("1824782123@qq.com", "sfyfpxyvxcazbbbd")

    //};
    public class MyFluentEmail
    {
        private string host = "smtp.qq.com";
        private bool enableSsl = true;
        private bool useDefaultCredentials = false;
        private SmtpDeliveryMethod smtp = SmtpDeliveryMethod.Network;
        private string authCode = "sfyfpxyvxcazbbbd";
        public string FromEmail;
        public string ToEmail;

        public SmtpClient CreateAClient()
        {
            return new SmtpClient()
            {
                Host = host,
                EnableSsl = enableSsl,
                UseDefaultCredentials = useDefaultCredentials,
                DeliveryMethod = smtp,
                Credentials = new NetworkCredential(FromEmail, authCode)
            };
        }
        public bool SendMessage(string title,string context)
        {
            var smtp = CreateAClient();
            Email.DefaultSender = new SmtpSender(smtp);
            var email = Email
            //发送人
            .From(FromEmail)
            //收件人
            .To(ToEmail)
            //抄送人
            .CC(ToEmail)
            //邮件标题
            .Subject(title)
            //邮件内容
            .Body(context,true);
            //依据发送结果判断是否发送成功
            var result = email.Send();

            return true;
        }

    }
}
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