using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopStoreCore.System
{
    public class SystemMenu
    {
        [Key]
        public int Id { get; set; }
        public string? MenuName { get; set; }

        [ForeignKey(name: "RootSystemMenu")]
        public int? ParentId { get; set; }
        public string? Url { get; set; }
        public SystemMenu? RootSystemMenu { get; set; }
    }
}
