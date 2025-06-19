using MediatR;
using Pizza.Domain.Common;
using Pizza.Domain.Entity.DTO;

namespace Pizza.Application.features.auth
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;
    }
    public class LoginCommandHendler(IRegister login) : IRequestHandler<LoginCommand, string>
    {
        private readonly IRegister _login = login;
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
          
        var user = new UserLoginDto
            {
                Email = request.Email,
                Password = request.Password,
            };
            var res = await _login.Login(user);
            return res;
        }
    }
}
