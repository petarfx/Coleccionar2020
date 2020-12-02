using System;
using System.Web.Security;
using System.Web.UI;
using DAL;

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
            int cantMsj = Views.getCantUnreadedMessagesByUser(Convert.ToInt32(Session["ID"]));
            lblMsj.Text = " " + cantMsj.ToString();
            btnMensajes.CssClass = cantMsj == 0 ? "btn btn-info btn-xs" : "btn btn-warning btn-xs";
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text.Trim();
            Response.Redirect(string.Format("BusquedaForm.aspx?filtro={0}", filtro));
        }

        #endregion

        protected void btnMensajes_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisMensajesForm.aspx");
        }
    }
}