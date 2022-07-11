using DataAccess.Context.Entity;

namespace WebShopServices.Managers
{
    public interface IUserManager
    {
        void AddUser(User user);

        User? GetUser(string email, string password);

        User? GetUser(int id);

        bool CheckIfUserEmailExists(string email);
    }
}
