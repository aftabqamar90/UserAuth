using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAuth.Interfaces;
using UserAuth.Models.Entities;
using UserAuth.Models.Requests.UserRequest;
using UserAuth.Models.Responses.UserResponse;

namespace UserAuth.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly Services.JwtService _jwtServices;
        private readonly Services.PasswordHasherService _passwordHasherService;
        public UserService(Services.PasswordHasherService _passwordHasherService, IUserRepository _userRepository, Services.JwtService _jwtService)
        {
            this._passwordHasherService = _passwordHasherService;
            this._userRepository = _userRepository;
            this._jwtServices = _jwtService;
        }
        public async Task CreateUser(CreateUserRequest model)
        {
            if ((await _userRepository.GetUserAsync(model.UserName) != null))
                throw new ArgumentException("User name already exist.");

            await _userRepository.CreateUserAsync(new CreateUserRequest
            {
                UserName = model.UserName,
                UserPassword = _passwordHasherService.HashPassword(model.UserPassword)
            });
        }

        public async Task<AuthUserResponse> Authenticate(AuthUserRequest model)
        {
            var result = await _userRepository.GetUserAsync(model.UserName, _passwordHasherService.HashPassword(model.UserPassword));
            if (result == null)
            {
                throw new ArgumentException("Invalid login.");
            }

            var response = new AuthUserResponse() { UserName = model.UserName, Id = result.Id };
            response.Token = _jwtServices.GenerateToken(response);
            return response;
        }
    }
}
