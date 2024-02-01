namespace WebMailer.Domain.Settings
{
    public class MailSettings
    {
        public string Host { get; set; } = "";
        public int Port { get; set; } = 2525;
        public bool SslEnabled { get; set; } = true;
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";

    }
}
