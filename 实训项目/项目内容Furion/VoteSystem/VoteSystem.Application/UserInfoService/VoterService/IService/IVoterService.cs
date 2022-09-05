

using VoteSystem.Application.VoteDto.VotersDto;

namespace VoteSystem.Application.UserInfoService.VoterService.IService
{
    public interface IVoterService
    {

        Task<int> PostAVote(VoterDto voterDto);
    }
}
