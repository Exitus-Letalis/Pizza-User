using Microsoft.AspNetCore.Mvc;
using MediatR;
using Pizza.Application.features.auth;
namespace Pizza.API.Controllers
{
    // Контролер для реєстрації та входу користувачів
    public class RegisterController(IMediator mediator) : ApiController
    {
        // Впровадження MediatR для обробки команд реєстрації та входу
        private readonly IMediator _mediator = mediator;
        // Конструктор контролера, який приймає MediatR
        [HttpPost("register")]
        // Метод для реєстрації нового користувача
        public async Task<ActionResult<string>> Registration([FromBody] RegistrationCommand command)
        {
            // Виклик команди реєстрації через MediatR
            var res = await _mediator.Send(command);
            // Повернення результату реєстрації
            return Ok(res);
        }
        // Метод для входу користувача
        [HttpPost("login")]
        // Використання атрибута FromBody для отримання даних з тіла запиту
        public async Task<ActionResult<string>> Login([FromBody] LoginCommand command)
        {
            // Виклик команди входу через MediatR
            var res = await _mediator.Send(command);
            // Повернення результату входу
            return Ok(res);
        }
    }
}
