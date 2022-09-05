 
 

namespace VoteSystem.Application.VoteService.IService
{
    public interface IUserService
    {
        Task<Users> LoginAscyn(LoginViewModel loginViewModel);

        Task<bool> Register(RegisterViewModel registerViewModel);

        Task<Users> UpdateUser(UpdateUserDto updateUserDto);

        Task<bool> UploadFileAsync(List<IFormFile> files);
    }
}
