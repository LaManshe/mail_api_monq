using mail_api_monq.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mail_api_monq.DAL.Entities
{
    /// <summary>
    /// Модель реализующая базовую сущность и основные свойства письма
    /// </summary>
    public class MailModel : IMailModel
    {
        /// <summary>
        /// Свойство получатель сообщения
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// Свойтсво была ли ошибка при отправке
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Свойство сообщения об ошибке
        /// </summary>
        public string FaultMessage { get; set; }
    }
}
