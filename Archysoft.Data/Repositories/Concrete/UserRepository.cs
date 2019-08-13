using System;
using System.Threading.Tasks;
using Archysoft.Data.Entities;
using Archysoft.Data.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Archysoft.Data.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserRepository(DataContext dataContext, UserManager<User> userManager, IPasswordHasher<User> passwordHasher) : base(dataContext)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public User Get(string email, string password)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user != null)
            {
                if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success)
                {
                    return user;
                }
            }

            return null;
        }

        public User Get(Guid id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            return user;
        }


        public IdentityResult CreateUser(User user, string password)
        {
            IdentityResult result = _userManager.CreateAsync(user, password).Result;
            if (result.Succeeded)
            {
                SaveChanges();
            }
            return result;
        }

        public string GeneratePasswordResetToken(User user)
        {
            return _userManager.GeneratePasswordResetTokenAsync(user).Result;
        }

        public async Task<IdentityResult> ResetPassword(string userId, string token, string password)
        {
            var user = _userManager.FindByIdAsync(userId).Result;
            IdentityResult result = await _userManager.ResetPasswordAsync(user, token, password);
            if (result.Succeeded)
            {
                SaveChanges();
            }
            return result;
        }
    }
}
