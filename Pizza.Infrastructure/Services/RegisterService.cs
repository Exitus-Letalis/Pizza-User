using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Common;
using Pizza.Domain.Entity;
using Pizza.Domain.Entity.DTO;
using Pizza.Infrastructure.persistense;


namespace Pizza.Infrastructure.Services
{
    // Реалізація сервісу реєстрації та логіну користувачів
    public class RegisterService(UserContext db) : IAuthService
    {
        // Контекст бази даних, який використовується для доступу до таблиці користувачів
        private readonly UserContext _db = db;
        // Метод для входу користувача
        public async Task<string> Login(UserLoginDto loginDto)
        {
            // Перевірка наявності користувача з таким email
            if (await _db.User.AnyAsync(user => user.Email.ToLower().Equals(loginDto.Email.ToLower())))
            {
                // Перевірка пароля користувача
                var user = await _db.User.SingleOrDefaultAsync(user => user.Email.ToLower().Equals(loginDto.Email.ToLower()));           
                // Якщо пароль збігається, повертаємо ID користувача
                if (user.Password==loginDto.Password)
                {
                    return (user.Id.ToString());
                }
            }
            return ("ErrorLogin");
        }

        // Метод для реєстрації нового користувача
        public async Task<string> Registration(UserRegistrDto registrationId)
        {
            // Перевірка валідності email, імені та пароля
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(registrationId.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            // Перевірка чи ім'я, пароль та email відповідають вимогам
            if (registrationId.Name == null || registrationId.Name.Length <= 4)
            {
                return ("ErrorName");
            }
            else if (registrationId.Password == null || registrationId.Password.Length <= 5)
            {
                return ("ErrorPassword");
            }
            else if (!isValid)
            {
                return ("ErrorEmail");
            }
            // Cтворення нового користувача
            var user = new User
            {
                Name = registrationId.Name,
                Email = registrationId.Email,
                Password = registrationId.Password
            };
            // Збереження користувача в базі даних
            var newUser = await _db.User.AddAsync(user);           
            // Перевірка, чи користувач успішно доданий
            await _db.SaveChangesAsync();           
            // Якщо додавання успішне, повертаємо ім'я користувача
            return (user.Name);
        }
    }   
}
