using mail_api_monq.DAL.Data;
using mail_api_monq.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace mail_api_monq.Data
{
    static class DbRegistrator
    {
        /// <summary>
        /// Инициализация сервиса по работе с БД
        /// </summary>
        /// <param name="services">Сервисы приложения</param>
        /// <param name="configuration">Конфигурация приложения</param>
        /// <returns>Добавленные сервисы в приложение</returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services
            .AddDbContext<AppDbContext>(
                options => options.UseMySql(configuration.GetConnectionString("RemoteCS_MySql"), new MySqlServerVersion(new Version(8, 0, 29))))
            .AddRepositoriesInDB()
            ;
        }
    }
}
