using VoteSystem.Core.Enums;

namespace VoteSystem.Core.VoteModelCore
{
    public class VoteActivity:Activity
    {
        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public ActivityCatagory Catagory { get; set; }//类别
        public int EachInvoteNumber { get; set; }//每个人的票数限制

        public List<ActivityManager> ActivityManagers { get; set; }
 
        public Admin Admin { get; set; }//发起人


    }
}
