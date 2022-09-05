//using RabbitMQComsumer;

//Console.WriteLine("Welcome to RabbitMQ Consumer!");
////DirectAcceptExchange();
////DirectAcceptExchangeEvent();
//RabbitMQComsumers.DirectAcceptExchangeTask();
////TopicAcceptExchange();
//Console.WriteLine("按任意值，退出程序");
//Console.ReadKey();



using RabbitMQ.Client;


using RabbitMQ.Client.Events;
using System.Text;
#region
//var factory = new ConnectionFactory() { HostName = "localhost" };
//using var connection = factory.CreateConnection();
//using var channel = connection.CreateModel();

//channel.QueueDeclare(queue: "task_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

//Console.WriteLine(" [*] Waiting for messages.");

//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (model, ea) =>
//{
//    var body = ea.Body.ToArray();
//    var message = Encoding.UTF8.GetString(body);
//    Console.WriteLine($" [x] Received {message}");
//};
//channel.BasicConsume(queue: "task_queue", autoAck: true, consumer: consumer);

//Console.WriteLine(" Press [enter] to exit.");
//Console.ReadLine();
#endregion
string exchangeName = "my";
string exchangeType = "direct";
string queueName = "testQueue";
string routeKey = "routeKey";

#region produce
var factory = new ConnectionFactory()
{
    HostName = "localhost"
};
var connect = factory.CreateConnection();
var channel = connect.CreateModel();

channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, true, true, null);//默认交换机不用声明交换机 但是发布的时候路由键要与队列名一致
//如果不是默认交换机 则要声明绑定队列
channel.QueueDeclare(queueName, true, false, true, null);

channel.QueueBind(queueName, exchangeName, routeKey, null);
var message = "hello";
var body = Encoding.UTF8.GetBytes(message);
channel.BasicPublish(exchangeName, routeKey, null, body);
#endregion


