using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Core.VoteModelCore
{
    public class VoteManager :IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }

        [ForeignKey("Voter")]
        public int VoterId { get; set; }

 
        public Candidate Candidate { get; set; }
 
        public Voter Voter { get; set; }
    }
}
