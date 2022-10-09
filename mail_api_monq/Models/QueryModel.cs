using mail_api_monq.DAL.Entities.Base;

namespace mail_api_monq.Models
{
    /// <summary>
    /// Модель для POST запроса, для отправки сообщения
    /// </summary>
    public class QueryModel
    {
        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Контент письма
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Список получателей сообщения
        /// </summary>
        public List<string> Recipients { get; set; }
    }
}
