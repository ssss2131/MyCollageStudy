using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Core.VoteModelCore
{
    public class Admin : Users
    {
        public Admin()
        {
            YourRole = Enums.YourRoles.Manager;
        }     
        public int ActivityId { get; set; }
 
        public List<VoteActivity> VoteActivities { get; set; }
    }
}
