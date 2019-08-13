using System;
using System.Threading.Tasks;
using Archysoft.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Archysoft.Data.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string email, string password);
        User Get(Guid id);
        string GeneratePasswordResetToken(User user);
        Task<IdentityResult> ResetPassword(string userId, string token, string password);
        IdentityResult CreateUser(User user, string password);
    }
}
