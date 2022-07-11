using DataAccess.Context;
using DataAccess.Context.Entity;

namespace WebShopServices.Managers
{
    public class UserManager : IUserManager
    {
        private readonly WebShopDbContext _context;

        public UserManager(WebShopDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();
            
        }

        public bool CheckIfUserEmailExists(string email)
        {
            bool isTaken;
            var user = _context.Users.FirstOrDefault(u => u.Email.Equals(email));
            isTaken = user != null;

            return isTaken;
        }

        public User? GetUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.Equals(email));
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
            return _context.Users.First(u => u.Id == id);
        }
    }
}
