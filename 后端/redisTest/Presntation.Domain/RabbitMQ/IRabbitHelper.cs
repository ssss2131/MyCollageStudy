using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.RabbitMQ
{
    //功能接口
    public interface IRabbitHelper
    {
        string SendMessage();

        void GetMessage();
        

    }
}
