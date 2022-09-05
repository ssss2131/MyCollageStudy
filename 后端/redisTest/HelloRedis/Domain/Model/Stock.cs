using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Domain
{
    public class Stock
    {         
        public Book? Book { get; set; }
        public int Id { get; set; }
        public int BookId { get; set; }

        public float Count { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
