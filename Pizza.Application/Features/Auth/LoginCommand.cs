using MediatR;
using Pizza.Domain.Common;
using Pizza.Domain.Entity.DTO;

namespace Pizza.Application.features.auth
{
    /// Команда для входу користувача
    public class LoginCommand : IRequest<string>
    {
        // команда для входу користувача
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;
    }
    /// Обробник команди входу користувача
    public class LoginCommandHendler(IRegister login) : IRequestHandler<LoginCommand, string>
    {
        // Обробник команди входу користувача
        private readonly IRegister _login = login;
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // створення об'єкта UserLoginDto з даними користувача

            var user = new UserLoginDto
            {
                Email = request.Email,
                Password = request.Password,
            };
            // Виклик методу входу
            var res = await _login.Login(user);
            // повернення результату входу
            return res;
        }
    }
}
