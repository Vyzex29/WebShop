using DataAccess.Context.Entity;

namespace WebShop.Extensions
{
    public static class UserSessionExtension
    {
        public static void SetSession(this ISession session, User user)
        {
            session.SetInt32("id", user.Id);
            session.SetString("username", user.Username);
            session.SetString("email", user.Email);
        }

        public static string? GetUsername(this ISession session)
        {
            return session.GetString("username");
        }
    }
}
