using System.Collections.Generic;
using System.Net.Mail;

namespace OurGames.UI.Services.Abstractions
{
    public interface IEmailSender
    {
        void Send(MailAddress to, string body, string subject,
            bool isBodyHtml = true,
            Dictionary<string, string> replacements = null,
            MailPriority priority = MailPriority.Normal);
    }
}
