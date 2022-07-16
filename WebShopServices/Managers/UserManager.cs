using DataAccess.Context.Entity;
using System.Diagnostics.CodeAnalysis;
using WebShopServices.Repositories;

namespace WebShopServices.Managers
{
    [ExcludeFromCodeCoverage]
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            if (user == null) 
            {
                throw new Exception("Cannot insert null as a user");
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _userRepository.Insert(user);
            
        }

        public bool CheckIfUserEmailExists(string email)
        {
            bool isTaken;
            var user = _userRepository.GetByEmail(email);
            isTaken = user != null;

            return isTaken;
        }

        public User? GetUser(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);

            if (user == null)
            {
                return null;
            }

            bool verified = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (verified)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public User? GetUser(int id)
        {
            var user = _userRepository.GetById(id);

            return user;
        }
    }
}
