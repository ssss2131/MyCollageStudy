using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteSystem.Core.VoteModelCore.RootModel;

namespace VoteSystem.Core.VoteModelCore
{
    public class Voter: Users
    {
        public Voter()
        {
            YourRole = Enums.YourRoles.Voter;
        }
        
        public bool IsBannedComment { get; set; }//是否被禁言
    }
}
