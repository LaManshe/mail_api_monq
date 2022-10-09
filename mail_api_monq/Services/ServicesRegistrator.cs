using mail_api_monq.Services.Interfaces;

namespace mail_api_monq.Services
{
    static class ServicesRegistrator
    {
        /// <summary>
        /// Метод добавляющий сервисы в приложение
        /// </summary>
        /// <param name="services">Сервисы приложения</param>
        /// <returns>Добавленные сервисы в приложение</returns>
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IMessageSender, SmtpMailSender>()
            .AddSingleton<ISmtpExecutor, MailKitExecutor>()
        ;
    }
}
