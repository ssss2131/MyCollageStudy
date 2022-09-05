using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using MyTodo.Shared;
using MyTodo.Shared.Dtos;

namespace MyTodoApi.Service.Authorization
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(ApiResponse<UserDto> response, out string token);
    }
}
