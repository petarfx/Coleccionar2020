using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.Wrappers;

namespace Coleccionar
{
    public partial class Mensaje : System.Web.UI.Page
    {
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Common.VerificaSesionActiva())
                Response.Redirect("IngresarForm.aspx");
            if (!Page.IsPostBack)
                CargarMensajes(Convert.ToInt32(Request.QueryString["id"]));
        }

        private void CargarMensajes(int idM)
        {
            MensajesWrapper mensaje = Views.getMessageByIdMensaje(idM);
            ClavarVisto(idM);
            DataToControls(mensaje);
        }

        private void ClavarVisto(int idM)
        {
            mensajeria msj = _ctx.mensajeria.Find(idM);
            msj.Leido = true;
            _ctx.SaveChanges();
        }

        private void DataToControls(MensajesWrapper obj)
        {
            txtPublicacion_Nombre.Text = obj.Publicacion_Nombre;
            txtFecha.Text = obj.Fecha.ToString();
            txtRemitente_Alias.Text = obj.Remitente_Alias;
            txtRemitente_Email.Text = obj.Remitente_Email;
            txtRemitente_Provincia_Descripcion.Text = obj.Remitente_Provincia_Descripcion;
            txtRemitente_Localidad_Descripcion.Text = obj.Remitente_Localidad_Descripcion;
            txtRemitente_Calle_Descripcion.Text = obj.Remitente_Calle_Descripcion;
            txtRemitente_Numero_Calle.Text = obj.Remitente_Numero_Calle != null ? obj.Remitente_Numero_Calle.ToString() : string.Empty;
            txtRemitente_Piso.Text = obj.Remitente_Piso != null ? obj.Remitente_Piso.ToString() : string.Empty;
            txtRemitente_Depto.Text = obj.Remitente_Depto != null ? obj.Remitente_Depto.ToString() : string.Empty; // ver nulos
            txtRemitente_Celular.Text = obj.Remitente_Celular != null ? obj.Remitente_Celular.ToString() : string.Empty;
            txtRemitente_Telefono.Text = obj.Remitente_Telefono != null ? obj.Remitente_Telefono.ToString() : string.Empty;
            txtMensajeCuerpo.Text = obj.Descripcion;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisMensajesForm.aspx");
        }
    }
}