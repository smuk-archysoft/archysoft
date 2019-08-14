using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Archysoft.Data.Entities;
using Archysoft.Data.Repositories.Abstract;
using Archysoft.Domain.Model.Services.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Archysoft.Domain.Model.Services.Concrete
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly UserManager<User> _userManager;
        private readonly ISettingsService _settingsService;
        private readonly IEmailNotificationService _emailNotificationService;
        public IUserRepository _userRepository { get; }

        public EmailNotificationService(IUserRepository userRepository, UserManager<User> userManager, ISettingsService settingsService)
        {
            _userManager = userManager;
            _settingsService = settingsService;
            _userRepository = userRepository;
        }
        public void SendMail(string email, string subject, string message)
        {
            var config = _settingsService.EmailNotificationSettings;
            var emailClient = new SmtpClient
            {
                Host = config.Host,
                Port = config.Port,
                EnableSsl = config.EnableSsl,
                UseDefaultCredentials = config.UseDefaultCredentials,
                Credentials = new NetworkCredential(config.Email, config.Password)
            };

            using (var msg = new MailMessage(config.Email, email, subject, message))
            {
                //emailClient.Send(msg);
            }
        }
    }
}
