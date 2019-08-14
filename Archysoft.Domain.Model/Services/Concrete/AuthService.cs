using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Archysoft.Data.Entities;
using Archysoft.Data.Repositories.Abstract;
using Archysoft.Domain.Model.Enums;
using Archysoft.Domain.Model.Exceptions;
using Archysoft.Domain.Model.Model.Auth;
using Archysoft.Domain.Model.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Archysoft.Domain.Model.Services.Concrete
{
    public class AuthService:IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISettingsService _settingsService;
        private readonly IEmailNotificationService _emailNotificationService;
        

        public AuthService(IUserRepository userRepository, ISettingsService settingsService, IEmailNotificationService emailNotificationService)
        {
            _userRepository = userRepository;
            _settingsService = settingsService;
            _emailNotificationService = emailNotificationService;          
        }

        public void EmailNotification(SignupModel model)
        {
            var isCreateUser = _userRepository.CreateUser(new User
            {
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = false
            }, model.Password);

            if (!isCreateUser.Succeeded)
            {
                throw new BusinessException(OperationResultCode.InvalidUser, "Error");
            }

            User user = _userRepository.Get().FirstOrDefault(x => x.Email == model.Email);          
            string token = Sha256Encryption.Sha256HexHashString(model.Email);
            string uiUrl = _settingsService.UIUrlSettings.Url;
            if (user != null)
            {
                string url = String.Format("{2}/auth/confirm-email?UserId={0}&Code={1}", user.Id, token, uiUrl);
                _emailNotificationService.SendMail(model.Email, "Notification", $"For confirm email, follow the link: {url}");
            }
            else
            {
                throw new BusinessException(OperationResultCode.InvalidUser, "Not found user with current email");
            }
        }

        public void ConfirmEmail(ConfirmEmailModel confirmEmailModel)
        {
            if (confirmEmailModel.UserId == null || confirmEmailModel.UserId == null)
            {
                throw new BusinessException(OperationResultCode.Error, "Wrong Data");
            }

            var id = new Guid(confirmEmailModel.UserId);          
            var user = _userRepository.Get().FirstOrDefault(x => x.Id == id);
            if (user == null || user.EmailConfirmed)
            {
                throw new BusinessException(OperationResultCode.Error, "NotValidToken");
            }
            var result = Sha256Encryption.Sha256HexHashString(user.Email);
            if (result == confirmEmailModel.Code)
            {
                user.EmailConfirmed = true;
                _userRepository.SaveChanges();
            }

            else
                throw new BusinessException(OperationResultCode.Error, "NotValidToken");
        }

        public void ForgotPasswordEmailNotification(ForgotPasswordModel model)
        {
            User user = _userRepository.Get().FirstOrDefault(x => x.Email == model.Email);

            if (user == null)
            {
                throw new BusinessException(OperationResultCode.InvalidUser, "Not found user with current email");
            }

            var token = _userRepository.GeneratePasswordResetToken(user);
            string uiUrl = _settingsService.UIUrlSettings.Url;
            string url = $"{uiUrl}/auth/recover-password/?id={user.Id}&token={HttpUtility.UrlEncode(token)}";

            _emailNotificationService.SendMail(user.Email,"Recover Password", $"To reset the password, follow the link: {url}");
        }

        public TokenModel Login(LoginModel loginModel)
        {
            var user = _userRepository.Get(loginModel.Login, loginModel.Password);
            if (user == null)
            {
                throw new BusinessException(OperationResultCode.Error, "Invalid User");
            }
            else if (!user.EmailConfirmed)
            {
                throw new BusinessException(OperationResultCode.Error, "Email Not Confirmed");
            }

            return GenerateToken(user);
        }

        private TokenModel GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settingsService.JwtSettings.Key));
            var signinCredentials=new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(_settingsService.JwtSettings.ExpireDays);

            var jwtToken=new JwtSecurityToken(
                _settingsService.JwtSettings.Issuer,
                null,
                claims,
                expires:expires,
                signingCredentials:signinCredentials);

            return new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                ExpiresIn = DateTime.UtcNow.AddDays(_settingsService.JwtSettings.ExpireDays)
            };
        }

        public void RecoverPassword(RecoverPasswordModel recoverPasswordModel)
        {
            Task<IdentityResult> taskResult = _userRepository.ResetPassword(recoverPasswordModel.UserId, recoverPasswordModel.Token, recoverPasswordModel.Password);
            var result = taskResult.Result;
            if (!result.Succeeded)
            {
                throw new BusinessException(OperationResultCode.InvalidUser, "Non authorized operation.");
            }
        }
    }
}
