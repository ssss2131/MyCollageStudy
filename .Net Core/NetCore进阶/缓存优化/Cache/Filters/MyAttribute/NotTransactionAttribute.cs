using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Filters.Attribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NotTransactionAttribute:System.Attribute
    {
    }
}
