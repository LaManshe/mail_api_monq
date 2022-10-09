using mail_api_monq.DAL.Entities;
using mail_api_monq.Interfaces;
using mail_api_monq.Services.Interfaces;

namespace mail_api_monq.Services
{
    /// <summary>
    /// Сервис, реализующий интерфейс IMessageSender для отправки сообщения и записи данных в БД
    /// </summary>
    public class SmtpMailSender : IMessageSender
    {
        private readonly IRepository<MailModel> _mailRepo;
        private readonly ISmtpExecutor _smptExecutor;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mailRepo">Репозиторий БД для работы с письмами</param>
        /// <param name="smptExecutor">Сервис исполнтиель отправки емайл сообщения</param>
        public SmtpMailSender(IRepository<MailModel> mailRepo, ISmtpExecutor smptExecutor)
        {
            _mailRepo = mailRepo;
            _smptExecutor = smptExecutor;
        }   
        /// <summary>
        /// Метод исполнитель отправки сообщений и записи в БД
        /// </summary>
        /// <param name="subject">Тема</param>
        /// <param name="body">Контент</param>
        /// <param name="recipinets">Получатели</param>
        /// <returns>Строку результат отправки сообщений</returns>
        public string SendTo(string subject, string body, params string[] recipinets)
        {
            string result = String.Empty;
            foreach(var recipinet in recipinets)
            {
                bool isFaulted = false;
                var message = _smptExecutor.SendSmtpMail(subject, body, recipinet);

                if(message != "Done")
                {
                    isFaulted = true;
                    result += String.Format($"Для {recipinet}: {message}\n");
                }

                _mailRepo.Add(new MailModel() 
                { 
                    Subject = subject, 
                    Body = body, 
                    Recipient = recipinet, 
                    Result = isFaulted ? "Failed" : "Ok", 
                    FaultMessage = isFaulted ? message : String.Empty, 
                    Created = DateTime.Now 
                });

            }
            
            if(result == String.Empty)
            {
                return "Done";
            }
            else
            {
                return result;
            }
        }
    }
}
