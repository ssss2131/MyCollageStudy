 
namespace VoteSystem.Core.VoteModelCore
{
    public class ActivityManager: IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("VoteActivity")]
        public int VoteActivityId { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        //活动中候选人获得的票数
        public int CandidateVoteNumber { get; set; }
        public VoteActivity VoteActivity { get; set; }
  
        public Candidate Candidate { get; set; }
    }
}
