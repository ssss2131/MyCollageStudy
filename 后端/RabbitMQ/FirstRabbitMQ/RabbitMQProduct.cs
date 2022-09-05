using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstRabbitMQ
{
    public class RabbitMQProduct
    {
        /// <summary>
        /// 连接配置
        /// </summary>
        private static readonly ConnectionFactory rabbitMqFactory = new ConnectionFactory()
        {
            UserName = "hao",
            Password = "abc123",
            Port = 5672,
            VirtualHost = "/"
        };
        /// <summary>
        /// 路由名称
        /// </summary>
        const string ExchangeName = "howdy.exchange";
        //队列名称
        const string QueueName = "howdy.queue";
        /// <summary>
        /// 路由名称
        /// </summary>
        const string TopExchangeName = "topic.howdy.exchange";

        //队列名称
        const string TopQueueName = "topic.howdy.queue";
        ///
        ///单点精确路由模式
        ///
        public static void DirectExchangeSendMsg()
        {
            using (IConnection conn = rabbitMqFactory.CreateConnection())//打开中间件的连接
            {
                using (IModel channel = conn.CreateModel())
                {
                    //声明交换器
                    channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);
                    //声明队列
                    channel.QueueDeclare(QueueName,durable:true,autoDelete:false,exclusive:false,arguments:null);
                    //绑定队列
                    channel.QueueBind(QueueName, ExchangeName, routingKey: QueueName);
                    var props = channel.CreateBasicProperties();
                    props.Persistent = true;
                    string vadata = Console.ReadLine();
                    while (vadata != "exit")
                    { 
                        var msgBody = Encoding.UTF8.GetBytes(vadata);
                        channel.BasicPublish(exchange: ExchangeName, routingKey: QueueName, basicProperties: props, body: msgBody);
                        Console.WriteLine($"发送时间+{DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss")}+发送完成,输入exit退出消息发送");
                        vadata = Console.ReadLine();
                    }

                }
            
            }
        
        }
        //模糊匹配模式
        public static void TopicExchangeSendMsg()
        {
            using (IConnection conn = rabbitMqFactory.CreateConnection())//打开中间件的连接
            {
                using (IModel channel = conn.CreateModel())
                {
                    //声明交换器
                    channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);
                    //声明队列
                    channel.QueueDeclare(QueueName, durable: true, autoDelete: false, exclusive: false, arguments: null);
                    //绑定队列
                    channel.QueueBind(QueueName, ExchangeName, routingKey: QueueName);
                    //var props = channel.CreateBasicProperties();
                    //props.Persistent = true;
                    string vadata = Console.ReadLine();
                    while (vadata != "exit")
                    {
                        var msgBody = Encoding.UTF8.GetBytes(vadata);
                        channel.BasicPublish(exchange: ExchangeName, routingKey: TopQueueName, basicProperties: null, body: msgBody);
                        Console.WriteLine($"发送时间+{DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss")}+发送完成,输入exit退出消息发送");
                        vadata = Console.ReadLine();
                    }

                }
            }
        }

    }
}
