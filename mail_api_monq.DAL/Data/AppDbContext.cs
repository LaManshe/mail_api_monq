using mail_api_monq.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mail_api_monq.DAL.Data
{
    /// <summary>
    /// Контекст базы данных в приложении
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Коллекция сущностей MailModel
        /// </summary>
        public DbSet<MailModel> Mails { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
