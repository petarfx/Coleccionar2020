using System;
using System.Web.Security;
using System.Web.UI;

namespace Coleccionar
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Nombre"] != null)
                {
                    SetearValoresDeSesion();
                }
            }
        }

        #region Private Methods
        
        private void SetearValoresDeSesion()
        {
            lblInfoUser.Text = String.Format("Bienvenido, {0}", Session["Nombre"].ToString());
            lblInfoUser.Visible = true;
            btnCerrarSesion.Visible = true;
        }
        private void ReestablecerVariablesDeSesion()
        {
            Session["ID"] = null;
            Session["Nombre"] = null;
            Session["Alias"] = null;
        }

        #endregion

        #region Eventos

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            ReestablecerVariablesDeSesion();
        }

        #endregion
    }
}