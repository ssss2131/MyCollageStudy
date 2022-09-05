using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopStoreCore.System.Provicy
{
    public class SystemOperation
    {
        [Key]
        public int Id { get; set; }
        public string? OperationName { get; set; }
        public IList<SystemOpRole>? SystemOpRole { get; set; }
    
    }
}
