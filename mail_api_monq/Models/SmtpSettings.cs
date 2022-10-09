namespace mail_api_monq.Models
{
    /// <summary>
    /// Модель для заполнения данных об отправителе из файла appsetting.json
    /// </summary>
    public class SmtpSettings
    {
        /// <summary>
        /// SMTP сервер для отправки сообщения
        /// </summary>
        public string Hostname { get; set; }
        /// <summary>
        /// Емейл с которого будет отправлено сообщение
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public string EmailName { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Порт SMTP сервера
        /// </summary>
        public int Port { get; set; }
    }
}
