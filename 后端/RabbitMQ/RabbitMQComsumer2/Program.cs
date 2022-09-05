using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//var factory = new ConnectionFactory() { HostName = "localhost" };
//using var connection = factory.CreateConnection();
//using var channel = connection.CreateModel();

//channel.QueueDeclare(queue: "task_queue4", durable: true, exclusive: false, autoDelete: false, arguments: null);

//channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

//Console.WriteLine(" [*] Waiting for messages.");

//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (model, ea) =>
//{
//    byte[] body = ea.Body.ToArray();
//    var message = Encoding.UTF8.GetString(body);
//    Console.WriteLine($" [x] Received {message}");

//    int dots = message.Split('.').Length - 1;
//    Thread.Sleep(1000);

//    Console.WriteLine(" [x] Done");

//    // here channel could also be accessed as ((EventingBasicConsumer)sender).Model
//    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
//};


//channel.BasicConsume(queue: "task_queue4", autoAck: false, consumer: consumer);

//Console.WriteLine(" Press [enter] to exit.");
//Console.ReadLine();

string queueName = "testQueue";
string routeKey = "testQueue";
List<string> mess = new List<string>();
var factory = new ConnectionFactory() { HostName = "localhost" };
var connect = factory.CreateConnection();
var channel = connect.CreateModel(); 
channel.QueueDeclare(queueName, true, false, true, null);
var channelEvent = new EventingBasicConsumer(channel);

channelEvent.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    mess.Add(message);
    Console.WriteLine(" [x] Received {0}", message);
  
};

channel.BasicConsume(queueName, true, channelEvent);

//Console.WriteLine(" Press [enter] to exit.");//这玩意不加 mess的总数为0 
//Thread.Sleep(1000);
Task.Run(() =>
{
    foreach (var item in mess)
    {
        Console.WriteLine(item);
    }
});


Console.ReadLine();