using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coleccionar
{
    public partial class SuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["titulo"] != null && Request.QueryString["mensaje"] != null)
                {
                    lblTitulo.Text = Request.QueryString["titulo"].ToString();
                    lblMensaje.Text = Request.QueryString["mensaje"].ToString();
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}