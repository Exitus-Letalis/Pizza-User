
using Pizza.Domain.Entity.DTO;

namespace Pizza.Domain.Common
{
    public interface IRegister
    {
        // Метод для реєстрації нового користувача
        Task<string> Registration(UserRegistrDto registrationId);
        // Метод для входу користувача 
        Task<string> Login(UserLoginDto loginDto);
    }
}
