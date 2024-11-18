using UserAuth.Models.Requests.UserRequest;
using UserAuth.Models.Responses.UserResponse;

namespace UserAuth.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(CreateUserRequest model);
        Task<GetUserResponse?> GetUserAsync(string UserName);
        Task<GetUserResponse?> GetUserAsync(string UserName, string UserPassword);
    }
}
