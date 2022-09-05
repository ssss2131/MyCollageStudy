using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Shared.Parameter
{
    public class FilterQueryParameter:QueryParameter
    {
        public int? Status { get; set; }
    }
}
