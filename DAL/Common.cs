using System.Web;

namespace DAL
{
    public static class Common
    {
        public static bool VerificaSesionActiva() => HttpContext.Current.User.Identity.IsAuthenticated;
    }
}
