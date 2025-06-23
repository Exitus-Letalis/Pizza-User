using MediatR;
using Pizza.Domain.Common;
using Pizza.Domain.Entity.DTO;

namespace Pizza.Application.features.auth
{
    // Команда для реєстрації нового користувача
    public class RegistrationCommand : IRequest<string>
    {
        // команда для реєстрації нового користувача
        public string Name { get; set; } = null;
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;

    }
    /// Обробник команди реєстрації користувача
    public class RegistrarionCommandHendler(IAuthService register ) : IRequestHandler<RegistrationCommand, string>

    {
        // Впровадження IRegister для реєстрації користувача
        private readonly IAuthService _register = register;
        // Обробник команди реєстрації користувача
        public async Task<string> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            // Створення об'єкта UserRegistrDto з даними користувача
            var user = new UserRegistrDto
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };
            // Виклик методу реєстрації з сервісу IRegister

            var res = await _register.Registration(user);
            // Повернення результату реєстрації
            return res;
           
        }
    }
}

    