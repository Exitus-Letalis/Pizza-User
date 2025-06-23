
namespace Pizza.Domain.Entity
{
    // Клас, що представляє користувача в системі
    public class User
    {
        // Унікальний ідентифікатор користувача
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
