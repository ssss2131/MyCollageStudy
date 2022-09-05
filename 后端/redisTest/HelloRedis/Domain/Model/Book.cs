using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Domain
{
    public class Book
    {
        public int BookId { get; set; }
 
        public string? BookName { get; set; }
  
        public DateTime CreateTime { get; set; }

        public string? Publisher { get; set; }
    
        public string? ISBN { get; set; }
        public int AuthorId { get; set; }
        //public int StockId { get; set; }
        public Author? Author { get; set; }

        //public Stock? Stock { get; set; } 
    }
}
