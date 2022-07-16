using DataAccess.Context.Entity;
namespace WebShopServices.Repositories
{
    public interface IUserRepository
    {
        public User GetById(int id);

        public User GetByEmail(string email);

        public void Insert(User user);
    }
}
