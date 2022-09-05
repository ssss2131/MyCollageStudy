using AutoMapper;
using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Extension;
using MyTodoApi.Context;
using MyTodoApi.Context.UnitOfWork;
using System.Threading.Tasks;

namespace MyTodoApi.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse> LoginAsync(string Account, string Password)
        {
            try
            {
                Password = Password.GetMD5();
                var user = await _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(predicate: x => x.Account.Equals(Account) && x.Password.Equals(Password));
                if (user != null)
                {
                    return new ApiResponse(true, user);
                }
                return new ApiResponse("密码或账号错误,请重新登录");
            }
            catch (System.Exception ex)
            {
                return new ApiResponse(ex.Message);
            }                  
        }

        public async Task<ApiResponse> RegisterAsync(UserDto model)
        {
            try
            {
                model.PassWord = model.PassWord.GetMD5();
                var Repository = _unitOfWork.GetRepository<User>();

                var isIn = await Repository.GetFirstOrDefaultAsync(predicate: x => x.Account.Equals(model.Account));
                if ( isIn !=null)
                {
                    return new ApiResponse($"账号:{model.Account}已存在!");
                }

                var user = _mapper.Map<User>(model);            
                var res = await Repository.InsertAsync(user);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, user);
                }
                return new ApiResponse("注册失败");
            }
            catch (System.Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
 
        }
    }
}
