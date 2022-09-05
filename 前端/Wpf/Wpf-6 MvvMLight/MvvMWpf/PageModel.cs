using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvMWpf
{
    public class PageModel
    {
        public string? CompanyName { get; set; }
        public List<Worker>? Workers { get; set; }
    }
    public record Worker(int id, string name, string role)
    { 
    }
}
