using DataAccess.Context.Entity;
using Moq;
using WebShopServices.Managers;
using WebShopServices.Repositories;

namespace WebShopServices.Tests.Managers
{
    internal class UserManagerTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private IUserManager _userManager;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userManager = new UserManager(_userRepositoryMock.Object);
        }

        [Test]
        public void GetUser_UserIdIsValid_ShouldReturnUser()
        {
            // ARRANGE
            int userId = 1;
            var expected = new User
            {
                Id = userId
            };
            _userRepositoryMock.Setup(urm => urm.GetById(userId)).Returns(new User { Id = 1 });
            // ACT
            var actual = _userManager.GetUser(userId);

            // ASSERT
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [Test]
        public void GetUser_UserIdDoesntExist_ShouldReturnNull()
        {
            // ARRANGE
            int userId = 1;
            _userRepositoryMock.Setup(urm => urm.GetById(userId)).Returns((User)null);

            // ACT
            var actual = _userManager.GetUser(userId);

            // ASSERT
            Assert.IsNull(actual);
        }

        [Test]
        public void CheckIfUserEmailExists_EmailExists_ShouldReturnTrue()
        {
            // ARRANGE
            string email = "test@email.com";
            _userRepositoryMock.Setup(urm => urm.GetByEmail(email)).Returns(new User());
            // ACT
            var actual = _userManager.CheckIfUserEmailExists(email);
            // ASSERT
            Assert.IsTrue(actual);
        }

        [Test]
        public void CheckIfUserEmailExists_EmailDoesntExist_ShouldReturnFalse()
        {
            // ARRANGE
            string email = "test@email.com";
            _userRepositoryMock.Setup(urm => urm.GetByEmail(email)).Returns((User)null);
            // ACT
            var actual = _userManager.CheckIfUserEmailExists(email);
            // ASSERT
            Assert.IsFalse(actual);
        }

        [Test]
        public void AddUser_UserIsValid_ShouldSucceed()
        {
            // ARRANGE
            User user = new User
            {
                Email = "test@email.com",
                Password = "password"
            };
            _userRepositoryMock.Setup(urm => urm.Insert(user)).Verifiable();

            // ACT
            _userManager.AddUser(user);

            // ASSERT
            _userRepositoryMock.Verify();
        }

        [Test]
        public void AddUser_UserIsNull_ShouldThrowNullReferenceException()
        {
            // ARRANGE

            // ACT
            var exception = Assert.Throws<Exception>(() => _userManager.AddUser((User)null));

            // ASSERT
            Assert.That(exception.Message == "Cannot insert null as a user");
        }

        [Test]
        public void GetUser_EmailAndPasswordValid_ShouldReturnUser()
        {
            string password = "password";

            // ARRANGE
            User user = new User
            {
                Email = "test@email.com",
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };
            _userRepositoryMock.Setup(urm => urm.GetByEmail(user.Email)).Returns(user).Verifiable();

            // ACT
            var actual = _userManager.GetUser(user.Email, password);

            // ASSERT
            _userRepositoryMock.Verify();
            Assert.IsNotNull(actual);
            Assert.AreEqual(user.Email, actual.Email);
        }

        [Test]
        public void GetUser_UserDoesntExist_ShouldReturnNull()
        {
            string password = "password";
            string email = "test@email.com";
            // ARRANGE

            _userRepositoryMock.Setup(urm => urm.GetByEmail(email)).Returns((User) null).Verifiable();

            // ACT
            var actual = _userManager.GetUser(email, password);

            // ASSERT
            _userRepositoryMock.Verify();
            Assert.IsNull(actual);
        }

        [Test]
        public void GetUser_EmailValidAndPasswordInValid_ShouldReturnNull()
        {
            string password = "password";
            string incorrectlyEnteredPassword = "pass";
            // ARRANGE
            User user = new User
            {
                Email = "test@email.com",
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };
            _userRepositoryMock.Setup(urm => urm.GetByEmail(user.Email)).Returns(user).Verifiable();

            // ACT
            var actual = _userManager.GetUser(user.Email, incorrectlyEnteredPassword);

            // ASSERT
            _userRepositoryMock.Verify();
            Assert.IsNull(actual);
        }
    }
}
