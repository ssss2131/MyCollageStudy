using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Domain
{
    public class Blog
    {
        public int BlogId { get; set; }

        [Comment("The URL of the blog")]
        public string? Url { get; set; }

        public IList<Post>? Posts { get; set; } 
    }
}
