using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopStoreCore.System.Provicy
{
    public class SystemRole
    {
        [Key]
        public int Id { get; set; }
        public string? RoleName { get; set; }

        public SystemOpRole? SystemOpRole { get; set; }

    }
}
