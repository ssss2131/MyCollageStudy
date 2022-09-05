using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.RabbitMQ
{
    //公共属性
    public class CommonMQ
    {
        protected ConnectionFactory? factory;
        public string? QueueName { get; set; }
        public string? Message { get; set; }
        public List<string>? ReciveMessage { get; set; } = new List<string>();
    }
}

