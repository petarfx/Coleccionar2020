using Coleccionar.Enums;
using Coleccionar.Wrappers;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coleccionar
{
    public partial class ComprarForm : System.Web.UI.Page
    {
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Common.VerificaSesionActiva())
                Response.Redirect("IngresarForm.aspx");

            if (!Page.IsPostBack)
            {
                CargarComboMediosDePago();
                CargarPublicacion();
            }
        }

        private void CargarPublicacion()
        {
            PublicacionesWrapper pub = Views.getPublicacionYFotoByIdUsuario(Convert.ToInt32(Request.QueryString["idpu"]));
            lblNombre.Text = pub.Nombre;
            lblPrecio.Text = pub.Precio.ToString("C", CultureInfo.CurrentCulture);
            lblCategoria.Text = pub.ID_Categoria_Descripcion;
            lblSubCategoria.Text = pub.ID_SubCategoria_Descripcion;
            usuario us = _ctx.usuario.Find(pub.ID_Usuario);
            ViewState["mail"] = us.Email;
            localidad lo = _ctx.localidad.Find(us.Domicilio_ID_Localidad);
            provincia prov = _ctx.provincia.Find(us.Domicilio_ID_Provincia);
            ViewState["Domicilio"] = string.Format("{0}, {1}, {2} {3} {4}{5}", prov.Descripcion, lo.Descripcion, us.Domicilio_Calle, us.Domicilio_Nro, us.Domicilio_Piso, us.Domicilio_Depto);
            string nombreArchivo = pub.Foto;
            string ruta = System.Configuration.ConfigurationManager.AppSettings["pathFotosPublicaciones"].ToString() + nombreArchivo;
            imgFoto.ImageUrl = ruta;
            ViewState["ID_Vendedor"] = pub.ID_Usuario;
            ViewState["NombrePub"] = pub.Nombre;
            ViewState["Precio"] = pub.Precio;
        }

        private void CargarComboMediosDePago()
        {
            List<tipoPago> tp = new List<tipoPago>();
            tp = _ctx.tipoPago.Where(x => x.Descripcion != "Mercado Pago").ToList();
            tp = tp.OrderBy(x => x.Descripcion).ToList();
            ddlMedioDePago.DataValueField = "ID_TipoPago";
            ddlMedioDePago.DataTextField = "Descripcion";
            ddlMedioDePago.DataSource = tp;
            ddlMedioDePago.DataBind();
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (ddlMedioDePago.SelectedItem.Text == "Tarjeta De Credito")
            {
                pnlPaso1.Visible = false;
                pnlTarjetaCredito.Visible = true;
            }
            else
            {
                pnlPaso1.Visible = false;
                cargarConfirmacion();
                pnlConfirmar.Visible = true;
            }
        }

        private void cargarConfirmacion()
        {
            lblCNombre.Text = lblNombre.Text;
            lblCPrecio.Text = lblPrecio.Text;
            lblCMetodoEntrega.Text = rbMetodoEntrega.SelectedItem.Text;
            lblCMedioPago.Text = ddlMedioDePago.SelectedItem.Text;
        }

        protected void rbMetodoEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbMetodoEntrega.SelectedIndex == 0)
            {
                lblMetodoEntrega.Text = string.Format("Se entregará en {0}", ViewState["Domicilio"].ToString());
            }
            else
            {
                lblMetodoEntrega.Text = "Acordar con el vendedor luego de efectuada la compra.";
            }
            lblMetodoEntrega.Visible = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            #region alta de venta
            venta vta = new venta();
            vta.ID_Publicacion = Convert.ToInt32(Request.QueryString["idpu"]);
            vta.ID_Vendedor = Convert.ToInt32(ViewState["ID_Vendedor"]);
            vta.ID_Comprador = Convert.ToInt32(Session["ID"]);
            vta.Fecha = DateTime.Now;
            vta.Estado = 1;
            vta.Importe = Convert.ToDouble(ViewState["Precio"]);
            vta.ID_TipoPago = Convert.ToByte(ddlMedioDePago.SelectedValue);
            _ctx.venta.Add(vta);
            _ctx.SaveChanges();
            #endregion

            #region modifico la Publicacion Original
            publicacion pub = _ctx.publicacion.Find(Convert.ToInt32(Request.QueryString["idpu"]));
            pub.Estado_Publicacion = (int)EnumEstado.Entregado;
            _ctx.SaveChanges();
            #endregion

            //Enviar Mensaje
            mensajeria msj = new mensajeria();
            msj.ID_Publicacion = Convert.ToInt32(Request.QueryString["idpu"]);
            msj.ID_Remitente = Convert.ToInt32(Session["ID"]);
            msj.ID_Destinatario = Convert.ToInt32(ViewState["ID_Vendedor"]);
            msj.Descripcion = string.Format("Felicitaciones, has vendido el producto '{0}'!", ViewState["NombrePub"].ToString());
            msj.Fecha = DateTime.Now;
            msj.Notificacion = true;
            msj.Leido = false;
            _ctx.mensajeria.Add(msj);
            _ctx.SaveChanges();


            string tituloOK = "¡Felicitaciones!";
            //string mensajeOK = string.Format("¡Has realizado una compra! Recibiras el detalle de tu compra al correo electrónico {0}", ViewState["mail"].ToString());
            string mensajeOK = string.Format("¡Has realizado una compra! Recibiras todos los datos brindados por el comprador en tu bandeja de entrada");
            Response.Redirect(string.Format("SuccessMessage.aspx?titulo={0}&mensaje={1}", tituloOK, mensajeOK));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnTSiguiente_Click(object sender, EventArgs e)
        {
            pnlTarjetaCredito.Visible = false;
            cargarConfirmacion();
            pnlConfirmar.Visible = true;
        }
    }
}