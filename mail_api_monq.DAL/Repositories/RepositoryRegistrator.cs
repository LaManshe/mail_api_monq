using mail_api_monq.DAL.Entities;
using mail_api_monq.DAL.Repositories;
using mail_api_monq.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace mail_api_monq.DAL.Repositories
{
    /// <summary>
    /// Статический класс, регистрирующий репозитории БД для сущностей 
    /// </summary>
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<MailModel>, Repository<MailModel>>()
        ;
    }
}
