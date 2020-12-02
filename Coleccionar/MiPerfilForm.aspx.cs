using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coleccionar.Enums;

namespace Coleccionar
{
    public partial class MiPerfilForm : System.Web.UI.Page
    {
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Common.VerificaSesionActiva())
                Response.Redirect("IngresarForm.aspx");

            if (!Page.IsPostBack)
            {               
                CargarDatos();
            }
        }
        private string FormatearFecha(DateTime birthday)
        {
            string fecha = birthday.ToShortDateString();
            fecha = fecha.Substring(6, 4) + "-" +   fecha.Substring(3, 2) + "-" + fecha.Substring(0, 2) ;
            return Convert.ToDateTime(fecha).ToString("yyyy-MM-dd");
        }

        private void CargarDatos()
        {
            int idUser = Convert.ToInt32(Session["ID"]);
            usuario user = _ctx.usuario.Where(x => x.ID_Usuario == idUser).First();

            txtAlias.Text = user.alias;
            txtApellido.Text = user.Apellido;
            txtNombre.Text = user.Nombre;
            txtEmail.Text = user.Email;
            txtDni.Text = user.Dni.ToString();
            txtFecNac.Value = FormatearFecha(user.Fecha_Nac);
            CargarProvincias();
            ddlProvincia.SelectedValue = user.Domicilio_ID_Provincia.ToString();
            CargarLocalidades(Convert.ToInt32(ddlProvincia.SelectedValue));
            ddlLocalidad.SelectedValue = user.Domicilio_ID_Localidad.ToString();
            txtCalle.Text = user.Domicilio_Calle;
            txtCalleNumero.Text = user.Domicilio_Nro.ToString();
            if (user.Domicilio_Piso != null)
                txtPiso.Text = user.Domicilio_Piso.ToString();
            if (user.Domicilio_Depto != null)
                txtDepto.Text = user.Domicilio_Depto.ToString();
            if (user.Telefono != null)
                txtTelefono.Text = user.Telefono.ToString();
            if (user.Celular != null)
                txtCelular.Text = user.Celular.ToString();
        }

        private void CargarProvincias()
        {
            #region Provincia
            List<provincia> prov = new List<provincia>();
            prov = _ctx.provincia.ToList();
            prov.Add(new provincia());
            prov = prov.OrderBy(x => x.Descripcion).ToList();
            ddlProvincia.DataValueField = "ID_Provincia";
            ddlProvincia.DataTextField = "Descripcion";
            ddlProvincia.DataSource = prov;
            ddlProvincia.DataBind();
            #endregion
        }

        private void CargarLocalidades(int idProv)
        {
            #region Localidades
            List<localidad> loc = new List<localidad>();
            loc = _ctx.localidad.Where(x => x.ID_Provincia == idProv).ToList();
            loc.Add(new localidad());
            loc = loc.OrderBy(x => x.Descripcion).ToList();
            ddlLocalidad.DataValueField = "ID_Localidad";
            ddlLocalidad.DataTextField = "Descripcion";
            ddlLocalidad.DataSource = loc;
            ddlLocalidad.DataBind();
            #endregion
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProv = Convert.ToInt32(ddlProvincia.SelectedValue);
            CargarLocalidades(idProv);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            botonesBloqueados();
            HabilitarCampos(true);
        }

        private void HabilitarCampos(bool estado)
        {
            ddlProvincia.Enabled = estado;
            ddlLocalidad.Enabled = estado;
            txtCalle.Enabled = estado;
            txtCalleNumero.Enabled = estado;
            txtPiso.Enabled = estado;
            txtDepto.Enabled = estado;
            txtTelefono.Enabled = estado;
            txtCelular.Enabled = estado;
        }

        private void modificarUsuario()
        {
            usuario user = _ctx.usuario.Find(Convert.ToInt32(Session["ID"]));
            //user.alias = txtAlias.Text.Trim();
            //user.Apellido = txtApellido.Text.Trim();
            //user.Nombre = txtNombre.Text.Trim();
            //user.Email = txtEmail.Text.Trim();
            //user.Dni = Convert.ToInt32(txtDni.Text);
            //user.Fecha_Nac = Convert.ToDateTime(txtFecNac.Value.ToString());
            user.Domicilio_ID_Provincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            user.Domicilio_ID_Localidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
            user.Domicilio_Calle = txtCalle.Text.Trim();
            user.Domicilio_Nro = Convert.ToInt32(txtCalleNumero.Text.Trim());
            if (txtPiso.Text.Trim() != string.Empty)
                user.Domicilio_Piso = Convert.ToInt32(txtPiso.Text.Trim());
            if (txtDepto.Text.Trim() != string.Empty)
                user.Domicilio_Depto = txtDepto.Text.Trim();
            //user.Domicilio_Lat = 1;
            //user.Domicilio_Lon = 1;
            if (txtTelefono.Text.Trim() != string.Empty)
                user.Telefono = Convert.ToInt64(txtTelefono.Text.Trim());

            if (txtCelular.Text.Trim() != string.Empty)
                user.Celular = Convert.ToInt32(txtCelular.Text.Trim());
            user.ID_Avatar = 1;

            //user.Clave = Encriptar.Encrypt(txtContraseña.Text);
            
            user.Estado = (int)EnumEstado.Activo;

            //if (ViewState["ID_Facebook"] != null)
            //    user.ID_Facebook = Convert.ToInt64(ViewState["ID_Facebook"].ToString());

            //_ctx.usuario.Add(user);
            _ctx.SaveChanges();
            HabilitarCampos(false);
            botonesEdicion();
            MensajeModificadoOk();
        }
        private void MensajeModificadoOk()
        {
            lblmsjTitulo.Text = "Modificación: ";
            lblmsjCuerpo.Text = "El usuario ha sido modificado correctamente.";
            divMensaje.Attributes["class"] = "showhide col-lg-10 col-lg-offset-1 alert-dismissible alert alert-success";
            ClientScript.RegisterStartupScript(GetType(), "mensajeshowhide", "MuestraOcultaMensaje();", true);
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            modificarUsuario();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarCampos(false);
            botonesEdicion();
        }

        private void botonesEdicion()
        {
            btnAceptar.Visible = false;
            btnEditar.Visible = true;
            btnCancelar.Visible = false;
        }

        private void botonesBloqueados()
        {
            btnAceptar.Visible = true;
            btnEditar.Visible = false;
            btnCancelar.Visible = true;
        }

    }
}