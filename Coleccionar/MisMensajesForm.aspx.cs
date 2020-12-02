using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;

namespace Coleccionar
{
    public partial class MisMensajesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Common.VerificaSesionActiva())
                Response.Redirect("IngresarForm.aspx");

            //if (!Page.IsPostBack)
            //{
            CargarMensajes(Convert.ToInt32(Session["ID"]));
            //}
        }

        private void CargarMensajes(int idS)
        {
            gvMensajes.DataSource = Views.getAllUnreadedMessagesByUsuario(idS).OrderByDescending(x=>x.Fecha);
            gvMensajes.DataBind();
        }

        protected void gvMensajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblid = (Label)gvMensajes.SelectedRow.FindControl("lblid");
            Response.Redirect(string.Format("Mensaje.aspx?id={0}", lblid.Text));
        }

        protected void gvMensajes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblid = (Label)e.Row.FindControl("lblid");
            if (lblid != null)
            {
                Label lblidRemitente = (Label)e.Row.FindControl("lblidRemitente");

                Label lblAliasRemitente = (Label)e.Row.FindControl("lblAliasRemitente");
                Label lblidnoti = (Label)e.Row.FindControl("lblidnoti");
                Label lblidleido = (Label)e.Row.FindControl("lblidleido");
                Label lblContenido = (Label)e.Row.FindControl("lblContenido");

                //LinkButton lnkVer = (LinkButton)e.Row.FindControl("lnkVer");

                //Controlar en PerfilForm que el id enviado no sea el mismo que e ld ela sesion, y no permitir modificar datos
                lblAliasRemitente.Attributes.Add("onclick", string.Format("javascript:window.location.href = 'PerfilForm.aspx?id={0}';", lblidRemitente.Text));
                
                lblContenido.Text = lblContenido.Text.Length > 40 ? lblContenido.Text.Substring(0, 40).Trim() + "..." : lblContenido.Text;

                LinkButton sobreCerrado = (LinkButton)e.Row.FindControl("sobreCerrado");
                LinkButton sobreAbierto = (LinkButton)e.Row.FindControl("sobreAbierto");
                if (Convert.ToBoolean(lblidleido.Text) == false)
                {
                    e.Row.Font.Bold = true;
                    e.Row.BackColor = Color.LightGoldenrodYellow;
                    sobreCerrado.Visible = true;
                }
                else
                    sobreAbierto.Visible = true;

                if (Convert.ToBoolean(lblidnoti.Text) == true)
                    lblAliasRemitente.Text = string.Format("Coleccionar ({0})", lblAliasRemitente.Text);
            }
        }
    }
}