using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Security.Cryptography;

namespace Coleccionar
{
    public partial class RegistrarForm : System.Web.UI.Page
    {
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
                setMaxLengthFields();
            }
        }

        private void setMaxLengthFields()
        {
            using (_ctx)
            {
                var objectContext = ((IObjectContextAdapter)_ctx).ObjectContext;
                var container = objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace);
                txtAlias.MaxLength = (int)container.EntitySets["usuario"].ElementType.Properties["alias"].MaxLength;
                txtApellido.MaxLength = (int)container.EntitySets["usuario"].ElementType.Properties["Apellido"].MaxLength;
                txtNombre.MaxLength = (int)container.EntitySets["usuario"].ElementType.Properties["Nombre"].MaxLength;
                txtCalle.MaxLength = (int)container.EntitySets["usuario"].ElementType.Properties["Domicilio_Calle"].MaxLength;
                txtDepto.MaxLength = (int)container.EntitySets["usuario"].ElementType.Properties["Domicilio_Depto"].MaxLength;
                txtEmail.MaxLength = (int)container.EntitySets["usuario"].ElementType.Properties["Email"].MaxLength;
                txtContraseña.MaxLength = (int)container.EntitySets["usuario"].ElementType.Properties["Clave"].MaxLength;
                txtContraseña2.MaxLength = (int)container.EntitySets["usuario"].ElementType.Properties["Clave"].MaxLength;
            }
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            try
            {
                List<usuario> user = _ctx.usuario.ToList();
                if (ValidarDatos(user))
                {
                    altaUsuario();
                }
            }
            catch (SqlNullValueException ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }

        private void altaUsuario()
        {
            usuario user = new usuario();
            user.alias = txtAlias.Text.Trim();
            user.Apellido = txtApellido.Text.Trim();
            user.Nombre = txtNombre.Text.Trim();
            user.Dni = Convert.ToInt32(txtDni.Text);
            user.Fecha_Nac = Convert.ToDateTime(txtFecNac.Value.ToString());
            user.Domicilio_ID_Provincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            user.Domicilio_ID_Localidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
            user.Domicilio_Calle = txtCalle.Text.Trim();
            user.Domicilio_Nro = Convert.ToInt32(txtCalleNumero.Text.Trim());
            if (txtPiso.Text.Trim() != string.Empty)
                user.Domicilio_Piso = Convert.ToInt32(txtPiso.Text.Trim());
            if (txtDepto.Text.Trim() != string.Empty)
                user.Domicilio_Depto = txtDepto.Text.Trim();
            user.Domicilio_Lat = 1;
            user.Domicilio_Lon = 1;
            if (txtTelefono.Text.Trim() != string.Empty)
                user.Telefono = Convert.ToInt64(txtTelefono.Text.Trim());

            if (txtCelular.Text.Trim() != string.Empty)
                user.Celular = Convert.ToInt32(txtCelular.Text.Trim());
            user.ID_Avatar = 1;

            user.Clave = Encriptar.Encrypt(txtContraseña.Text);
            user.Email = txtEmail.Text.Trim();
            user.Estado = 1;
            _ctx.usuario.Add(user);
            _ctx.SaveChanges();
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtAlias.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDni.Text = "";
            txtFecNac.Value = "";
            ddlProvincia.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            txtCalle.Text = "";
            txtCalleNumero.Text = "";
            txtPiso.Text = "";
            txtDepto.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
        }

        private bool ValidarDatos(List<usuario> user)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                var alias = user.Where(a => a.alias == txtAlias.Text.Trim()).ToList();
                var email = user.Where(a => a.Email == txtEmail.Text.Trim()).ToList();

                if (alias.Any())
                    throw new SqlNullValueException("El Alias ingresado ya existe, por favor seleccione uno distinto.");
                if (email.Any())
                    throw new SqlNullValueException("Ya existe un usuario registrado con ese correo electrónico, por favor ingrese una distinta");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}