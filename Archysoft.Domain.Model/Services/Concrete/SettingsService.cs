using Archysoft.Domain.Model.Model.Settings;
using Archysoft.Domain.Model.Services.Abstract;

namespace Archysoft.Domain.Model.Services.Concrete
{
    public class SettingsService : ISettingsService
    {
        public JwtSettings JwtSettings { get; set; }
        public EmailNotificationSettings EmailNotificationSettings { get; set; }
        public UIUrlSettings UIUrlSettings { get; set; }


        public SettingsService
        (
            JwtSettings jwtSettings,
            EmailNotificationSettings emailNotificationSettings,
            UIUrlSettings uiUrlSettings
        )
        {
            JwtSettings = jwtSettings;
            EmailNotificationSettings = emailNotificationSettings;
            UIUrlSettings = uiUrlSettings;
        }
    }
}
