using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Core.Model
{
    public class Person : Entity
    {
        public Person()
        {
            CreatedTime = DateTimeOffset.Now;
        }

        [MaxLength(32)]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }
    }
}
