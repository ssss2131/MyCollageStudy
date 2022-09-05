using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Core.VoteModelCore.RootModel
{
    public class Activity :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime WhenStart { get; set; }
        public DateTime WhenEnd { get; set; }
    }
}
