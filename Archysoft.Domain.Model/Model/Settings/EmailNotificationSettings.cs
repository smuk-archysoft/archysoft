namespace Archysoft.Domain.Model.Model.Settings
{
    public class EmailNotificationSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}