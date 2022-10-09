using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mail_api_monq.DAL.Entities.Base
{
    /// <summary>
    /// Абстрактный класс, добавляющий необходимые свойства сущности и свойства по заполнению письма
    /// </summary>
    public abstract class IMailModel : IEntity
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
        /// Дата отправления письма
        /// </summary>
        public DateTime Created { get; set; }
    }
}
