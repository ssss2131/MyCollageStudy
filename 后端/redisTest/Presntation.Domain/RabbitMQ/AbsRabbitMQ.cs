using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.RabbitMQ
{
    //用户需求
    public abstract class AbsRabbitMQ : CommonMQ/*, IRabbitHelper*/
    {
        public abstract void GetMessage();


        public abstract string SendMessage();
       
  
    }
}
