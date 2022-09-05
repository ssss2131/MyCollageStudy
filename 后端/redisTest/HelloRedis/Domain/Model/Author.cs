using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Domain
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string? AuthorName { get; set; }
 
        public DateTime BirthTime { get; set; }

        public List<Book>? Books { get; set; }

    }
}
