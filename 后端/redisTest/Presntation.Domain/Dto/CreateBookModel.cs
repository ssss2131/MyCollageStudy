using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Dto
{
    public class CreateBookModel
    {
        public string? BookName { get; set; }
        public string? ISBN { get; set; }
        public string? Publisher { get; set; }
        public int AuthorId { get; set; }
        public int Count { get; set; }
    }
}
