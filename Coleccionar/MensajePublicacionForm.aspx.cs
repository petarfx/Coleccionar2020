using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coleccionar.Wrappers;
using DAL;
using DAL.Wrappers;

namespace Coleccionar
{
    public partial class MensajePublicacionForm : System.Web.UI.Page
    {
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Common.VerificaSesionActiva())
                Response.Redirect("IngresarForm.aspx");

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    CargarDatosPublicacion(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
        }

        private void CargarDatosPublicacion(int idPub)
        {
            PublicacionesWrapper msj = Views.getPublicacionDatosByIdUsuario(idPub);
            DataToControls(msj);
        }

        private void DataToControls(PublicacionesWrapper msj)
        {
            txtDestinatario_Alias.Text = msj.UsuarioAlias;
            txtPublicacion_Nombre.Text = msj.Nombre;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            publicacion pubOrig = _ctx.publicacion.Find(Convert.ToInt32(Request.QueryString["id"]));

            mensajeria objm = new mensajeria();
            objm.ID_Destinatario = pubOrig.ID_Usuario;
            objm.Descripcion = txtMensajeCuerpo.Text;
            objm.ID_Remitente = Convert.ToInt32(Session["ID"]);
            objm.ID_Publicacion = Convert.ToInt32(Request.QueryString["id"]);
            objm.Fecha = DateTime.Now;
            objm.Notificacion = false;
            objm.Leido = false;
            _ctx.mensajeria.Add(objm);
            _ctx.SaveChanges();

            txtMensajeCuerpo.Text = string.Empty;
            MensajeEnviadoOk();
        }

        private void MensajeEnviadoOk()
        {
            lblmsjTitulo.Text = "Mensaje Publicado ";
            lblmsjCuerpo.Text = "Mensaje enviado correctamente.";
            divMensaje.Attributes["class"] = "showhide col-lg-10 col-lg-offset-1 alert-dismissible alert alert-success";
            ClientScript.RegisterStartupScript(GetType(), "mensajeshowhide", "MuestraOcultaMensaje();", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}