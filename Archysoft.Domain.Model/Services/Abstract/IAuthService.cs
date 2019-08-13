using Archysoft.Domain.Model.Model.Auth;

namespace Archysoft.Domain.Model.Services.Abstract
{
    public interface IAuthService
    {
        TokenModel Login(LoginModel loginModel);
        void EmailNotification(SignupModel model);
        void ConfirmEmail(ConfirmEmailModel confirmEmailModel);
        void ForgotPasswordEmailNotification(ForgotPasswordModel model);
        void RecoverPassword(RecoverPasswordModel recoverPasswordModel);
    }
}
