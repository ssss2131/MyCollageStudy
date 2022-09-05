using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MyMqLib
{
    public class MyRabbitmq
    {
        private bool exclusive = false;
        private string queueName="myQueue";
        private bool durable=true;
        private bool autoDelete=false;
        public List<string> Result = new List<string>();

        public IConnection Connect()
        {
            var fact = new ConnectionFactory() { HostName = "localhost" };
            var connection = fact.CreateConnection();
            return connection;
        }
        public void SendMessage(string Message)
        {
            var con = Connect();
            var channel = con.CreateModel();
            channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);
            var body = Encoding.UTF8.GetBytes(Message);
            channel.BasicPublish("", queueName, null, body);
        }
        public void GetMessage()
        {
            using var con = Connect();
            var channel = con.CreateModel();
            channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);

            var comsumer = new EventingBasicConsumer(channel);
         
            comsumer.Received += (model,ea) => {
                var body =  ea.Body.Span;
                if (ea.Redelivered == false)//判断消息是否已经被接收过了
                {
                    var message = Encoding.UTF8.GetString(body);

                    Console.WriteLine(" [x] Received {0}", message);

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
           


            };
            channel.BasicConsume(queueName, false, comsumer);




        }

    }
}