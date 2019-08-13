using Archysoft.Domain.Model.Enums;
using Archysoft.Domain.Model.Model.Auth;
using Archysoft.Domain.Model.Services.Abstract;
using Archysoft.Web.Api.Model;
using Archysoft.Web.Api.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ConfirmEmailModel = Archysoft.Domain.Model.Model.Auth.ConfirmEmailModel;
using LoginModel = Archysoft.Domain.Model.Model.Auth.LoginModel;

namespace Archysoft.Web.Api.Controllers
{
    public class AuthController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(RoutePaths.Login)]
        public ApiResponse<TokenModel> Login([FromBody] LoginModel model)
        {
            TokenModel token = _authService.Login(model);
            return new ApiResponse<TokenModel>(token);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(RoutePaths.SignUp)]
        public ApiResponse Signup([FromBody] SignupModel model)
        {
            _authService.EmailNotification(model);
            return new ApiResponse(OperationResultCode.Success, "Success");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(RoutePaths.ConfirmEmail)]
        public ApiResponse ConfirmEmail([FromBody] ConfirmEmailModel confirmEmailModel)
        {
            _authService.ConfirmEmail(confirmEmailModel);
            return new ApiResponse();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(RoutePaths.ForgotPassword)]
        public ApiResponse ForgotPassword([FromBody] ForgotPasswordModel email)
        {
            _authService.ForgotPasswordEmailNotification(email);
            return  new ApiResponse();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(RoutePaths.RecoverPassword)]
        public ApiResponse RecoverPassword([FromBody] RecoverPasswordModel recoverPasswordModel)
        {
            _authService.RecoverPassword(recoverPasswordModel);
            return new ApiResponse();
        }
    }
}
