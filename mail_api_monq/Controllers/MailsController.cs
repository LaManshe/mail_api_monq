using mail_api_monq.DAL.Entities;
using mail_api_monq.Interfaces;
using mail_api_monq.Models;
using mail_api_monq.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace mail_api_monq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IMessageSender _messageSender;
        private readonly IRepository<MailModel> _mailRepo;
        public MailsController(IMessageSender messageSender, IRepository<MailModel> mailRepo)
        {
            _messageSender = messageSender;
            _mailRepo = mailRepo;
        }

        /// <summary>
        /// Точка GET запроса по url /api/mails
        /// </summary>
        /// <returns>Результат метода действия в формате json</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mailRepo.Items);
        }

        /// <summary>
        /// Точка POST запроса по url /api/mails
        /// </summary>
        /// <param name="model">Тело передаваемого объекта в формате json</param>
        /// <returns>Результат метода действия Ok в формате json или Problem в формате problem+json</returns>
        [HttpPost]
        public IActionResult Post([FromBody] QueryModel model)
        {
            FieldInfo[] fields = model
                .GetType()
                .GetFields(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                var val = field.GetValue(model);
                if (val == String.Empty || val == null)
                {
                    return Problem(
                        title: $"Поле {nameof(field.Name)} не может быть пустым");
                }
            }

            string result = _messageSender.SendTo(model.Subject, model.Body, model.Recipients.ToArray());
            if (result == "Done")
            {
                return Ok(result);
            }
            else
            {
                return Problem(
                    title: "Возникла проблема со следующими получателями см. detail",
                    detail: result);
            }
        }
    }
}
