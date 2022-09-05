using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Tools.RabbitMQ;

namespace Tools.RabbitMQ
{
    //具体实现用户需求(实现对不同模式下RabbitMQ的扩展)
    public class RabbitMQHelper:AbsRabbitMQ
    {
      
        public override string SendMessage()
        {
            factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "task_queue", durable: true/*此处保证服务器停掉消息不会丢失*/, exclusive: false, autoDelete: false, arguments: null);

            if (Message != null)
            {
                var body = Encoding.UTF8.GetBytes(Message);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish("", "task_queue", properties, body);
                return "消息已发送";
            }
            
            Console.WriteLine("书写异常");
                                                  
            return "消息未发送";
        }
        public override void GetMessage()
        {
            factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "task_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                this.ReciveMessage.Add(message);
                Console.WriteLine($" [x] Received {message}");            

                Console.WriteLine(" [x] Done");

                // here channel could also be accessed as ((EventingBasicConsumer)sender).Model
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            channel.BasicConsume(queue: "task_queue", autoAck: false, consumer: consumer);
            
            Console.WriteLine(" Press [enter] to exit.");
           
        }

    }
}
