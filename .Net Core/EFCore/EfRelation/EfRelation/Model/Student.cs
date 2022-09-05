using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfRelation.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public DateTime JoinDay { get; set; } = DateTime.Now;

        public Teacher? Teacher { get; set; }
    }
}
