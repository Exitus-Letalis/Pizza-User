using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework.Legacy;
using Pizza.Domain.Entity.DTO;
using Pizza.Infrastructure.persistense;
using Pizza.Infrastructure.Services;


namespace TestRegistration.Test
{
    // Тестовий клас для перевірки сервісу реєстрації користувачів
    public class Tests
    {
        // Тест для перевірки правильності даних при реєстрації користувача
        [Test]
        public async Task Password_lengs()
        {
            // Створюємо об'єкт UserRegistrDto з даними користувача
            var userDto = new UserRegistrDto
            {
                Name = "Ioann",
                Email = "Lock@gmail.com",
                Password = "dfd"
            };

            //Симулюємо контекст бази даних
            var moking = new Mock<UserContext>(new DbContextOptions<UserContext>());
            
            //Створюємо сервіс реєстрації
            var servise = new RegisterService(moking.Object);
            
            //Викликаємо метод реєстрації
            var result = await servise.Registration(userDto);
            
            //Перевіряємо результат
            ClassicAssert.AreEqual("ErrorPassword", result);

        }
        [Test]
        public async Task Email_is_valid()
        {
            var userDto = new UserRegistrDto
            {
                Name = "Ioann",
                Email = "Lockg",
                Password = "123456"
            };
            var moking = new Mock<UserContext>(new DbContextOptions<UserContext>());
            var servise = new RegisterService(moking.Object);
            var result = await servise.Registration(userDto);

            ClassicAssert.AreEqual("ErrorEmail", result);
        }

        [Test]
        public async Task Name_lengs()
        {
            var userDto = new UserRegistrDto
            {
                Name = "Io",
                Email = "Lock@gmail.com",
                Password = "123456"
            };
            var moking = new Mock<UserContext>(new DbContextOptions<UserContext>());
            var servise = new RegisterService(moking.Object);
            var result = await servise.Registration(userDto);

            ClassicAssert.AreEqual("ErrorName", result);


        }

       
    }
}

