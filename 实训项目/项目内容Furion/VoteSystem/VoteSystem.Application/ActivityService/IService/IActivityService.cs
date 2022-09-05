 
using VoteSystem.Application.VoteDto.ActivityDto;
 

namespace VoteSystem.Application.ActivityService.IService
{
    public interface IActivityService
    {
        /// <summary>
        /// 新增一个投票活动
        /// </summary>
        /// <param name="voteActivityDto"></param>
        /// <returns></returns>
        Task<VoteActivity> PostAVoteActivity(VoteActivityDto voteActivityDto);

        Task<PagedList<VoteActivity>> GetAllVoteActivity(int size,int index);
         
        
    }
}
