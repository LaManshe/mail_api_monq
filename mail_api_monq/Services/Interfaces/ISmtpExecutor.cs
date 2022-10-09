namespace mail_api_monq.Services.Interfaces
{
    /// <summary>
    /// Интерфейс исполнитель отправки сообщения
    /// </summary>
    public interface ISmtpExecutor
    {
        /// <summary>
        /// Метод исполнитель отправки сообщения
        /// </summary>
        /// <param name="subject">Тема</param>
        /// <param name="body">Контент</param>
        /// <param name="recipient">Получатель</param>
        /// <returns>Строку результат отправки сообщения</returns>
        string SendSmtpMail(string subject, string body, string recipient);
    }
}
