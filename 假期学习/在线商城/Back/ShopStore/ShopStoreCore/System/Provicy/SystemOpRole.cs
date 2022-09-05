using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopStoreCore.System.Provicy
{
    public class SystemOpRole
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(name: "SystemRole")]
        public int SystemRoleId { get; set; }
        [ForeignKey(name: "SystemOperation")]
        public int SystemOperationId { get; set; }

        public  SystemRole? SystemRole { get; set; }       
        public  SystemOperation? SystemOperation { get; set; }
    }
 
}
