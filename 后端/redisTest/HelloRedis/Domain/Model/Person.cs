using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string Name => "${FirstName}+{LastName}";
        [ConcurrencyCheck]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
   
    }
}
