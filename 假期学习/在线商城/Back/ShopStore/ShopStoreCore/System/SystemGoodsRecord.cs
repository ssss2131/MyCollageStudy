using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopStoreCore.System
{
    public class SystemGoodsRecord
    {
        [Key]
        public int Id { get; set; }
        public DateTime BuyTime { get; set; }
        public bool IsHandled { get; set; }
        [ForeignKey(name: "SystemUser")]
        public int UserId { get; set; }
        [ForeignKey(name: "SystemGoods")]
        public int GoodId { get; set; }

        public SystemUser? SystemUser { get; set; }
        public SystemGoods? SystemGoods { get; set; }
    }
}
