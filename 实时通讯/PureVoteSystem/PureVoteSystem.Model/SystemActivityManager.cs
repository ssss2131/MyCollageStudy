using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureVoteSystem.Model
{
    /// <summary>
    /// 活动馆
    /// </summary>
    public class SystemActivityManager
    {
        [Key]
        public int Id { get; set; }

        public int SystemUserId { get; set; }
        public int SystemActivityId { get; set; }
        public SystemUser SystemUser { get; set; }
        public SystemActivity SystemActivity { get; set; }
    }
}
