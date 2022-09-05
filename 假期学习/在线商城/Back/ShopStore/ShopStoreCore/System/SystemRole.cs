using ShopStoreCore.System.Provicy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopStoreCore.System
{
    public class SystemRole
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public IList<SystemOpRole>? SystemOpRole { get; set; }


        public IList<SystemUser>? SystemUser { get; set; }
    }
}
