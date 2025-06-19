
using Pizza.Domain.Entity.DTO;

namespace Pizza.Domain.Common
{
    public interface IRegister
    {
        Task<string> Registration(UserRegistrDto registrationId);
        Task<string> Login(UserLoginDto loginDto);
    }
}
