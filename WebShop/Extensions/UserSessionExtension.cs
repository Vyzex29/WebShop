using DataAccess.Context.Entity;

namespace WebShop.Extensions
{
    public static class UserSessionExtension
    {
        public static void SetSession(this ISession session, User user, Cart cart)
        {
            session.SetInt32("id", user.Id);
            session.SetString("username", user.Username);
            session.SetString("email", user.Email);
            session.SetInt32("cartId", cart.Id);
            session.SetString("UserRole", user.Role.ToString());
        }

        public static string? GetUsername(this ISession session)
        {
            return session.GetString("username");
        }

        public static int? GetUserId(this ISession session)
        {
            return session.GetInt32("id");
        }

        public static int? GetCartId(this ISession session)
        {
            return session.GetInt32("cartId");
        }

        public static string? GetUserRole(this ISession session)
        {
            return session.GetString("UserRole");
        }
    }
}
