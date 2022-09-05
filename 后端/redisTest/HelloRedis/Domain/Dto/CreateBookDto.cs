using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Domain.Dto
{
    public class CreateBookDto
    {
        public int AuthorId { get; set; }
        public string BookName { get; set; }
     
    }
}
