using Microsoft.AspNetCore.Mvc;
using UserAuth.Models.Requests.UserRequest;
using UserAuth.Models.Responses.UserResponse;


namespace UserAuth.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController : ControllerBase
    {
        private readonly Services.UserService _userService;
        public AccountController(Services.UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task Post(CreateUserRequest model)
        {
            await _userService.CreateUser(model);
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<AuthUserResponse> Authenticate(AuthUserRequest model)
        {
            return await _userService.Authenticate(model);
        }
    }
}
