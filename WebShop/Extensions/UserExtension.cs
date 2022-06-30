using DataAccess.Context.Entity;
using WebShop.Models;

namespace WebShop.Extensions
{
    public static class UserExtension
    {
        public static User ToEntity(this CreateUserModel user)
        {
            var createdUser = new User
            {
                Username = user.UserName,
                Email = user.Email,
                Password = user.Password
            };

            return createdUser;
        }
    }
}
