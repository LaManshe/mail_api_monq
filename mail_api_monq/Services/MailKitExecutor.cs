using mail_api_monq.Models;
using mail_api_monq.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace mail_api_monq.Services
{
    /// <summary>
    /// Класс реализующий ISmtpExecutor для отправки сообщения, использующий библиотеку MailKit
    /// </summary>
    public class MailKitExecutor : ISmtpExecutor
    {
        private SmtpClient _smtpClient;
        private readonly IConfiguration _configuration;
        private SmtpSettings _smtpSettings;
        /// <summary>
        /// Контсруктора исполнителя отправки емайл сообщения
        /// </summary>
        /// <param name="configuration">Конфигурация приложения</param>
        public MailKitExecutor(IConfiguration configuration)
        {
            _configuration = configuration;

            _smtpSettings = _configuration.GetSection("SMTPConfiguration").Get<SmtpSettings>();

            _smtpClient = new SmtpClient();
            _smtpClient.Connect(_smtpSettings.Hostname, _smtpSettings.Port, true);
            _smtpClient.Authenticate(_smtpSettings.Email, _smtpSettings.Password);
        }
        /// <summary>
        /// Метод отправки сообщения, средствами MailKit
        /// </summary>
        /// <param name="subject">Тема</param>
        /// <param name="body">Контент</param>
        /// <param name="recipient">Получатель</param>
        /// <returns></returns>
        public string SendSmtpMail(string subject, string body, string recipient)
        {
            string resultMessage = String.Empty;
            bool isFault = false;

            if (!_smtpClient.IsConnected)
            {
                resultMessage += "Не удалось подключиться ";
                isFault = true;
            }
            if (!_smtpClient.IsAuthenticated)
            {
                resultMessage += "Не удалось получить доступ к аккаунту";
                isFault = true;
            }

            if (!isFault)
            {
                try
                {
                    MimeMessage mailMessage = new MimeMessage();
                    mailMessage.From.Add(new MailboxAddress(_smtpSettings.EmailName, _smtpSettings.Email));
                    mailMessage.To.Add(new MailboxAddress(recipient, recipient));
                    mailMessage.Subject = subject;
                    mailMessage.Body = new BodyBuilder() { TextBody = body }.ToMessageBody();

                    _smtpClient.Send(mailMessage);

                    resultMessage = "Done";
                }
                catch(SmtpCommandException ex)
                {
                    resultMessage += ex.Message + " ";
                }
                catch (Exception ex)
                {
                    resultMessage += ex.Message;
                }
            }

            return resultMessage;
        }
    }
}
