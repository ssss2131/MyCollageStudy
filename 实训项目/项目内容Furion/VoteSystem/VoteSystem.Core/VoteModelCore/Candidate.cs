using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteSystem.Core.VoteModelCore.RootModel;

namespace VoteSystem.Core.VoteModelCore
{
    public class Candidate:Users
    {
        public Candidate()
        {
            YourRole = Enums.YourRoles.Candidate;
        }
        public string Canvassing { get; set; }//拉票内容
 　
 
        public List<ActivityManager> ActivityManagers { get; set; }//活动管理

        public List<VoteManager> VoteManagers { get; set; }//投票管理
    }
}
