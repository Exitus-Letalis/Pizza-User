using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework.Legacy;
using Pizza.Domain.Entity.DTO;
using Pizza.Infrastructure.persistense;
using Pizza.Infrastructure.Services;


namespace TestRegistration.Test
{
    // �������� ���� ��� �������� ������ ��������� ������������
    public class Tests
    {
        // ���� ��� �������� ����������� ����� ��� ��������� �����������
        [Test]
        public async Task Password_lengs()
        {
            // ��������� ��'��� UserRegistrDto � ������ �����������
            var userDto = new UserRegistrDto
            {
                Name = "Ioann",
                Email = "Lock@gmail.com",
                Password = "dfd"
            };

            //��������� �������� ���� �����
            var moking = new Mock<UserContext>(new DbContextOptions<UserContext>());
            
            //��������� ����� ���������
            var servise = new RegisterService(moking.Object);
            
            //��������� ����� ���������
            var result = await servise.Registration(userDto);
            
            //���������� ���������
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

