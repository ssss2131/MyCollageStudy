 
using VoteSystem.Application.ActivityService.IService;
using VoteSystem.Application.VoteDto.ActivityDto;
 

namespace VoteSystem.Application.ActivityService.ServiceImp
{
    [DynamicApiController]
    public class ActivityServiceImp : IActivityService
    {
        private IRepository<VoteActivity> _repository;

        public ActivityServiceImp(IRepository<VoteActivity> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 查询所有活动
        /// </summary>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PagedList<VoteActivity>> GetAllVoteActivity(int size, int index)
        {

           
            return await _repository.AsQueryable().ToPagedListAsync(index, size);
        }
        /// <summary>
        /// 通过活动标题查询活动
        /// </summary>
        /// <param name="title"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<PagedList<VoteActivity>> QueryVoteActivityByTitle(string title,int size, int index)
        {
            return await _repository.AsQueryable(c=>c.Title.Contains(title)).ToPagedListAsync(index,size);
        }
        /// <summary>
        /// 通过日期查询活动
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<PagedList<VoteActivity>> QueryVoteActivityByTime(string from, string to, int size, int index)
        {
            var start = Convert.ToDateTime(from);
            var end = Convert.ToDateTime(to);   
            return await _repository.AsQueryable(c => c.WhenStart>= start && c.WhenEnd<= end).ToPagedListAsync(index,size);
        }
        

        /// <summary>
        /// 新增一个投票活动
        /// </summary>
        /// <param name="voteActivityDto"></param>
        /// <returns></returns>
        public async Task<VoteActivity> PostAVoteActivity(VoteActivityDto voteActivityDto)
        {
            var activity = voteActivityDto.Adapt<VoteActivity>();

            await _repository.InsertAsync(activity);
            return activity;
        }
       
    }
}
