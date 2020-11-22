using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace DAL
{
    public static class Common
    {
        public static bool VerificaSesionActiva() => HttpContext.Current.User.Identity.IsAuthenticated;
    }
}
