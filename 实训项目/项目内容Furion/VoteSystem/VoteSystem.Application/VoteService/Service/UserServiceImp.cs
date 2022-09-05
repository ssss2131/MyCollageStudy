using Microsoft.Extensions.Logging;
using VoteSystem.Application.Utils.UserTools;
 
namespace VoteSystem.Application.VoteService.Service
{
    [DynamicApiController]
    public class UserServiceImp : IUserService
    {
        private readonly IRepository<Users> _userRep;
        private readonly ILogger _logger;

        public UserServiceImp(IRepository<Users> userRep/*,ILogger logger*/ )
        {
            _userRep = userRep;
            //_logger = logger;
        }
        //登录
        public async Task<Users> LoginAscyn(LoginViewModel loginViewModel)
        {
            loginViewModel.Password = PassWordHash.encrypt(loginViewModel.Password);
            var user = await _userRep.FirstOrDefaultAsync(c=>c.Account == loginViewModel.UserName );
            if(user!=null)
            {
                if (loginViewModel.Password == user.Password)
                {
                    //var text = JsonSerializer.Serialize(user);
                    return user;
                }
                throw new Exception("密码不正确");
            }

            throw new Exception("信息不存在");
        }      

        //注册
        public async Task<bool> Register(RegisterViewModel registerViewModel)
        {           
            Users myUser = null;
            var check = await _userRep.FirstOrDefaultAsync(c => c.Account == registerViewModel.UserName) == null ? "No" : "Account";
            check = await _userRep.FirstOrDefaultAsync(c => c.PhoneNumber == registerViewModel.Phone) == null ? check : "Phone";
            check = await _userRep.FirstOrDefaultAsync(c => c.Email == registerViewModel.Email) == null ? check : "Email";

            switch (check)
            {
                case "No":
                    break;
                case "Account":
                    throw new Exception("账号已存在");
                case "Phone":
                    throw new Exception("手机号已存在");
                case "Email":
                    throw new Exception("邮箱已存在");
                default:
                    _logger.LogError("位置:VoteSystem.Application.VoteService.Service ---Register出现不和逻辑的错误但不影响运行");
                    break;
            }

            registerViewModel.Password = PassWordHash.encrypt(registerViewModel.Password);
            switch (registerViewModel.YourRoles)
            {
                case  YourRoles.Voter:
                    myUser = registerViewModel.Adapt<Voter>();                          
                    break;
                case  YourRoles.Candidate:
                    myUser = registerViewModel.Adapt<Candidate>();
                    break;
                case YourRoles.Manager:
                    myUser = registerViewModel.Adapt<Admin>();
                    break;                  
            }
            var res = await _userRep.InsertAsync(myUser);

            return true;
        }
        /// <summary>
        /// 修改用户基本信息
        /// </summary>
        /// <param name="updateUserDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Users> UpdateUser(UpdateUserDto updateUserDto)
        {
         
            var user = updateUserDto.Adapt<Users>();
            await _userRep.UpdateAsync(user);
            return user;
        }
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost, NonUnify]
        public async Task<bool> UploadFileAsync(List<IFormFile> files)
        {
            // 保存到网站根目录下的 uploads 目录
            var savePath = Path.Combine(App.HostEnvironment.ContentRootPath, "uploads");
            if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);
            long size = files.Sum(f => f.Length);
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // 避免文件名重复，采用 GUID 生成
                    var filePath = Path.Combine(savePath, Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName));  // 可以替代为你需要存储的真实路径
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            // 在动态 API 直接返回对象即可，无需 OK 和 IActionResult
            return true;
        }
        /// <summary>
        /// 用户头像上传
        /// </summary>
        /// <param name="fileDto"></param>
        /// <returns></returns>
        [HttpPost, NonUnify]
        public async Task<UploadFileDto> UploadFileAsync2([FromForm]UploadFileDto fileDto)
        {
            var user = _userRep.FirstOrDefault(c => c.Id == fileDto.UserId);
            var files = fileDto.files;
            // 保存到网站根目录下的 uploads 目录
            var savePath = Path.Combine(App.HostEnvironment.ContentRootPath, "uploads");
            if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);
            long size = files.Sum(f => f.Length);
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // 避免文件名重复，采用 GUID 生成
                    var filePath = Path.Combine(savePath, Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName));  // 可以替代为你需要存储的真实路径
                    if (string.IsNullOrEmpty(user.Img))
                    {
                        user.Img = filePath;
                    }
                    else
                    {
                        File.Delete(user.Img);
                        user.Img = filePath;
                    }
                    _userRep.Update(user);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            // 在动态 API 直接返回对象即可，无需 OK 和 IActionResult
            return fileDto;

        }

    }
}
