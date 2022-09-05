using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfRelation.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IList<Student>? Students { get; set; }
    }
}
