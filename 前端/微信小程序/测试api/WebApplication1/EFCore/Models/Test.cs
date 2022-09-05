using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public record Test(string Name,string Age,DateTime when)
    {
        public int Id { get; set; }
    }
}
