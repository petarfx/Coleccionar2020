using System;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using DAL;
using System.Linq;

namespace Coleccionar
{
    public partial class Default : System.Web.UI.Page
    {
        public const string FaceBookAppKey = "7d417dde660429e84723fb76eb7f7c70";
        private char[] userInfo;

        void Page_PreInit(Object sender, EventArgs e)
        {
            setMasterPage();
        }
        private void setMasterPage()
        {
            this.MasterPageFile = !Common.VerificaSesionActiva() ? "~/LoggedOut.Master" : "~/LoggedIn.Master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}