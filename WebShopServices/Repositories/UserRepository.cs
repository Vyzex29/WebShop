using DataAccess.Context;
using DataAccess.Context.Entity;
using System.Diagnostics.CodeAnalysis;

namespace WebShopServices.Repositories
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : IUserRepository
    {
        private readonly IWebShopDbContext _context;

        public UserRepository(IWebShopDbContext context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.Equals(email));

            return user;
        }

        public User GetById(int id)
        {
            return _context.Users.First(u => u.Id == id);
        }

        public void Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
