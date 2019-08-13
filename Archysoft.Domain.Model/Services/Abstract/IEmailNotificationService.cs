namespace Archysoft.Domain.Model.Services.Abstract
{
    public interface IEmailNotificationService
    {
        void SendMail(string email, string subject, string message);
    }
}