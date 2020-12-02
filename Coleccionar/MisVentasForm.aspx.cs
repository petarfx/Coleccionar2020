using Coleccionar.Enums;
using Coleccionar.Wrappers;
using DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Web.UI.WebControls.Image;

namespace Coleccionar
{
    public partial class MisVentasForm : System.Web.UI.Page
    {
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Common.VerificaSesionActiva())
                Response.Redirect("IngresarForm.aspx");

            cargarVentas(Convert.ToInt32(Session["ID"]));
        }

        private void cargarVentas(int idUser)
        {
            List<PublicacionesWrapper> pub = Views.getAllPublicacionActivasByIdUsuario(idUser);
            if (pub.Any())
            {
                gvVentasPublicadas.DataSource = pub;
                gvVentasPublicadas.DataBind();
            }
        }

        protected void gvVentasPublicadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblid = (Label)e.Row.FindControl("lblid");
            if (lblid != null)
            {
                Label idFoto = (Label)e.Row.FindControl("idFoto");
                if (idFoto != null)
                {
                    Image imgFoto = (Image)e.Row.FindControl("imgFoto");
                    if (imgFoto != null)
                    {
                        string nombreArchivo = idFoto.Text;
                        string ruta = System.Configuration.ConfigurationManager.AppSettings["pathFotosPublicaciones"].ToString() + nombreArchivo;
                        imgFoto.ImageUrl = ruta;
                        imgFoto.Attributes.Add("onclick", string.Format("javascript:window.location.href = 'VerPublicacionForm.aspx?id={0}';", lblid.Text));
                    }
                }

                Label lblTipoPublicacion = (Label)e.Row.FindControl("lblTipoPublicacion");
                if (lblTipoPublicacion != null)
                {
                    if (Convert.ToInt32(lblTipoPublicacion.Text) == (int)EnumTipoPublicacion.Venta)
                        e.Row.BackColor = Color.FromArgb(207, 252, 191);
                    else
                        e.Row.BackColor = Color.FromArgb(191, 208, 252);
                }
            }
        }
    }
}