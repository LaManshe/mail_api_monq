using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mail_api_monq.Interfaces
{
    /// <summary>
    /// Базовая сущность с идентификатором
    /// </summary>
    public class IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int Id { get; set; }
    }
}
