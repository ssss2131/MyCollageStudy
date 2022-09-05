using Microsoft.AspNetCore.SignalR;
using PuroVoteSystem.Mvc.Models.EchartsDto;

namespace PuroVoteSystem.Mvc.HubS
{
    public class ChatHub:Hub
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accessor;

        public ChatHub(AppDbContext context,IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }
       /// <summary>
       /// 异步消息发送方法
       /// </summary>
       /// <param name="userr">用户名</param>
       /// <param name="message">消息</param>
       /// <returns></returns>
        public async Task SendMessage(string userr, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userr, message);//通过method标识这个方法,后面为传递过来的参数       
        }

        public async Task ShowData(string actId)
        {
            var info = _context.SystemCandidateManager.Where(c => c.SystemActivityId == int.Parse(actId)).Include(c => c.SystemActivity).Include(c => c.SystemUser).Where(c => c.SystemUser.RoleId == 2).AsQueryable();
            var echartModels = new List<EchartsViewModel>();
            foreach (var item in info)
            {
                echartModels.Add(new EchartsViewModel { userName = item.SystemUser.UserName, voteNumber = item.CountVote });
            }   
            await Clients.All.SendAsync("PleaseEchartsData", echartModels);
        }
    #region 分组发送消息

        /// <summary>
        /// 添加到分组
        /// </summary>
        /// <param name="groupName">组名</param>
        /// <returns>object</returns>
        public async Task AddToGroup(string groupName)
        {
            var userName = _accessor.HttpContext.User.Identity.Name;
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);


            await Clients.Group(groupName).SendAsync("Send", $"{userName} has joined the group {groupName}.");
        }
        /// <summary>
        /// 通过 消息发送到指定分组
        /// </summary>
        /// <param name="groupName">组名</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public Task SendMessageToGroup(string groupName, string message)
        {
            var name = _accessor.HttpContext.User.Identity.Name;
            return Clients.Group(groupName).SendAsync("Send", $"{name}: {message}");
        }
    #endregion
    }
}
