namespace mail_api_monq.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для реализации отправки сообщений и записи в БД
    /// </summary>
    public interface IMessageSender
    {
        /// <summary>
        /// Метод для отправки сообщения и записи в БД
        /// </summary>
        /// <param name="subject">Тема письма</param>
        /// <param name="body">Контент письма</param>
        /// <param name="recipients">Получатели</param>
        /// <returns>Строку результата отправки сообщений</returns>
        string SendTo(string subject, string body, params string[] recipients);
    }
}
