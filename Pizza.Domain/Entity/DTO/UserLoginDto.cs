

namespace Pizza.Domain.Entity.DTO
{
    // DTO для входу користувача
    public class UserLoginDto
    {
        // Дані користувача для входу
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;
    }
}
