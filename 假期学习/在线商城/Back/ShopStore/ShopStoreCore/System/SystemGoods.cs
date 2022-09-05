using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopStoreCore.System
{
    public class SystemGoods
    {
        [Key]
        public int Id { get; set; }
        public string? GoodsName { get; set; }
        [ForeignKey(name: "GoodsType")]
        public int GoodsTypeId { get; set; }
        public decimal GoodsPrice { get; set; }
        public double CountInStore { get; set; }
        public bool OnSeal { get; set; }
        public double CountInSeal { get; set; }

        
        public GoodsType? GoodsType { get; set; }
    }
    public class GoodsType
    {
        [Key]
        public int Id { get; set; }
        public string? TypeName { get; set; }
        public int CountInType { get; set; }
    }
}
