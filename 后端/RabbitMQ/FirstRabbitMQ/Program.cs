﻿using FirstRabbitMQ;
using RabbitMQ.Client;





using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "task_queue4", durable: true/*此处保证服务器停掉消息不会丢失*/, exclusive: false, autoDelete: false, arguments: null);

var message = GetMessage(args);
var body = Encoding.UTF8.GetBytes(message);

var properties = channel.CreateBasicProperties();
properties.Persistent = true;

//string text = Console.ReadLine();
//string[] textList = text.Split(" ");
//foreach (var item in textList)
//{
//    var bo = Encoding.UTF8.GetBytes(item);
//    channel.BasicPublish(exchange: "", routingKey: "task_queue", basicProperties: properties, body: bo);
//}

channel.BasicPublish(exchange: "", routingKey: "task_queue4", basicProperties: null, body: body);
Console.WriteLine($" [x] Sent {message}");

Console.WriteLine(" Press [enter] to exit.");


static string GetMessage(string[] args)
{
    return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
}
//Console.WriteLine("Welcome to RabbitMQ Product!");
//RabbitMQProduct.DirectExchangeSendMsg();
//// TopicExchangeSendMsg();
//Console.WriteLine("按任意值，退出程序");
//Console.ReadKey();
//using RabbitMQ.Client;
//using System.Text;


//var factory = new ConnectionFactory() { HostName = "localhost" };
//using var connection = factory.CreateConnection();
//using var channel = connection.CreateModel();

//channel.QueueDeclare(queue: "task_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

//string message = "Hello World!";
//var body = Encoding.UTF8.GetBytes(message);

//channel.BasicPublish(exchange: "", routingKey: "task_queue", basicProperties: null, body: body);
//Console.WriteLine($" [x] Sent {message}");

//Console.WriteLine(" Press [enter] to exit.");
//Console.ReadLine();