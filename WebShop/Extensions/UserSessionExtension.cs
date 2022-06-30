using DataAccess.Context.Entity;

namespace WebShop.Extensions
{
    public static class UserSessionExtension
    {
        public static void SetSession(this HttpContext context, User user)
        {
            context.Session.SetInt32("id", user.Id);
            context.Session.SetString("username", user.Username);
            context.Session.SetString("email", user.Email);
        }

        public static string GetUsername(this HttpContext context)
        {
            return context.Session.GetString("username");
        }
    }
}
