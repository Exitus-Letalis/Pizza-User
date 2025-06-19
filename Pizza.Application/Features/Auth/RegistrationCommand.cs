using MediatR;
using Pizza.Domain.Common;
using Pizza.Domain.Entity.DTO;

namespace Pizza.Application.features.auth
{
    public class RegistrationCommand : IRequest<string>
    {
        public string Name { get; set; } = null;
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;

    }

    public class RegistrarionCommandHendler(IRegister register ) : IRequestHandler<RegistrationCommand, string>

    {
        private readonly IRegister _register = register;
            public async Task<string> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var user = new UserRegistrDto
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };

            var res = await _register.Registration(user);
            return res;
           
        }
    }
}

    