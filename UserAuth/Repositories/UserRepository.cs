using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using UserAuth.Data;
using UserAuth.Interfaces;
using UserAuth.Models.Entities;
using UserAuth.Models.Requests.UserRequest;
using UserAuth.Models.Responses.UserResponse;

namespace UserAuth.Repositories
{
    public class UserRepository : Interfaces.IUserRepository
    {
        private readonly Data.Db _context;
        private readonly Services.PasswordHasherService _passwordHasherService;
        public UserRepository(Data.Db _context, Services.PasswordHasherService _passwordHasherService)
        {
            this._context = _context;
            this._passwordHasherService = _passwordHasherService;
        }

        public async Task CreateUserAsync(CreateUserRequest model)
        {
            await _context.Users.AddAsync(new User() { UserName = model.UserName, UserPassword = model.UserPassword });
            await _context.SaveChangesAsync();
        }

        public async Task<GetUserResponse?> GetUserAsync(string UserName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(ee => ee.UserName.ToLower() == UserName.ToLower());
            if (user == null)
                return null;
            return new GetUserResponse() { UserName = user.UserName, Id = user.Id };
        }

        public async Task<GetUserResponse?> GetUserAsync(string UserName, string UserPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(ee => ee.UserName.ToLower() == UserName.ToLower() && ee.UserPassword == UserPassword);
            if (user == null)
                return null;
            return new GetUserResponse() { UserName = user.UserName, Id = user.Id };
        }
    }
}