using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Common;
using Pizza.Domain.Entity;
using Pizza.Domain.Entity.DTO;
using Pizza.Infrastructure.persistense;


namespace Pizza.Infrastructure.Services
{
    public class RegisterService(UserContext db) : IRegister
    {
        private readonly UserContext _db = db;
        public async Task<string> Login(UserLoginDto loginDto)
        {

            if (await _db.User.AnyAsync(user => user.Email.ToLower().Equals(loginDto.Email.ToLower())))
            {
                var user = await _db.User.SingleOrDefaultAsync(user => user.Email.ToLower().Equals(loginDto.Email.ToLower()));
                if (user.Password==loginDto.Password)
                {
                    return (user.Id.ToString());
                }
            }
            return ("ErrorLogin");
        }

        public async Task<string> Registration(UserRegistrDto registrationId)
        {
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(registrationId.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
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

            var user = new User
            {
                Name = registrationId.Name,
                Email = registrationId.Email,
                Password = registrationId.Password
            };
            var newUser = await _db.User.AddAsync(user);
            await _db.SaveChangesAsync();
            return (user.Name);
        }
    }   
}
