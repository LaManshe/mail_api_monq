using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace mail_api_monq.DAL.Entities.Base
{
    /// <summary>
    /// Абстрактный класс базового свойства сущности для БД
    /// </summary>
    public abstract class IEntity
    {
        /// <summary>
        /// Идентификатор сущности, является ключом для сущности
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
