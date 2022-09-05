using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.RabbitMQ
{
    public class RabbitMqPub_Subs : AbsRabbitMQ, IRabbitHelper
    {
        public override void GetMessage()
        {
            factory = new ConnectionFactory { HostName = "localhost" };
            using var con = factory.CreateConnection();
            using var channel = con.CreateModel();
            channel.ExchangeDeclare("Publish-Subscribe", "fanout");
            var name = channel.QueueDeclare().QueueName;//声明临时队列
            channel.QueueBind(name, "Publish-Subscribe", "hello");
         
            var commsuer = new EventingBasicConsumer(channel);
            commsuer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine(message);
                base.ReciveMessage.Add(message);
            };
            channel.BasicConsume(name, true, commsuer);
            Console.WriteLine("发布订阅消费完成");
           
        }

        public override string SendMessage()
        {
            factory = new ConnectionFactory { HostName = "localhost" };
            using var con = factory.CreateConnection();
            using var channel = con.CreateModel();
            channel.ExchangeDeclare("Publish-Subscribe", "fanout");//将channel绑定到交换机,使用扇形交换机
            //假设消息不为空
            var body = Encoding.UTF8.GetBytes(Message);
            channel.BasicPublish(exchange: "Publish-Subscribe", routingKey: "hello", basicProperties: null, body: body);
            Console.WriteLine("消息已发送");

            return "Ok";
        }
    }
}
