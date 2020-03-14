using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OurGames.Core.Entity;
using OurGames.UI.Services.Abstractions;

namespace OurGames.UI.Services
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _emailSettings { get; }

        public EmailSender(IOptions<OurGamesUIConfig> config)
        {
            _emailSettings = config.Value.EmailSettings;
        }

        public void Send(MailAddress to, string body, string subject, bool isBodyHtml = true, Dictionary<string, string> replacements = null, MailPriority priority = MailPriority.Normal)
        {
            using (var client = new SmtpClient()
            {
                Host = _emailSettings.Host,
                Port = _emailSettings.Port,
                DeliveryMethod = (SmtpDeliveryMethod)Enum.Parse(typeof(SmtpDeliveryMethod), _emailSettings.DeliveryMethod),
                EnableSsl = _emailSettings.EnableSsl,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailSettings.From, _emailSettings.Password)
            })
            {
                var mail = new MailMessage
                {
                    Subject = subject,
                    Body = ReplaceBodyContentKeys(body, replacements),
                    IsBodyHtml = isBodyHtml,
                    Priority = priority
                };

                mail.From = new MailAddress(_emailSettings.From, _emailSettings.DisplayName);

                mail.To.Add(to);

                client.Timeout = Convert.ToInt32(TimeSpan.FromMinutes(5).TotalMilliseconds);

                client.Send(mail);
            }
        }

        private static string ReplaceBodyContentKeys(string bodyContent, Dictionary<string, string> replacements)
        {
            if (replacements is null)
                return bodyContent;

            foreach (var key in replacements.Keys)
            {
                bodyContent = bodyContent.Replace(key, replacements[key]);
            }

            return bodyContent;
        }
    }
}
