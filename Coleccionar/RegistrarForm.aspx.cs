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
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Coleccionar.Enums;
using System.Web.Security;

namespace Coleccionar
{
    public partial class RegistrarForm : System.Web.UI.Page
    {
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Common.VerificaSesionActiva())
                    Response.Redirect("IngresarForm.aspx");

                if (string.IsNullOrEmpty(Request.QueryString["access_token"])) return; //ERROR! No token returned from Facebook!!

                //let's send an http-request to facebook using the token            
                string json = GetFacebookUserJSON(Request.QueryString["access_token"]);

                //and Deserialize the JSON response
                JavaScriptSerializer js = new JavaScriptSerializer();

                FaceBookUser oUser = js.Deserialize<FaceBookUser>(json);
                if (oUser != null)
                {
                    ColeccionarEntities ctx = new ColeccionarEntities();
                    //Busco el usuario por el Id de facebook
                    usuario user = ctx.usuario.Where(x => x.ID_Facebook == oUser.id).FirstOrDefault();

                    if (user != null)
                    {
                        //Existe el Usuario, y ya tiene la cuenta asociada a FaceBook
                        CargarDatosEnSesion(user);
                        FormsAuthentication.RedirectFromLoginPage("A", false);
                    }
                    else
                    {
                        //El usuario entra por primera vez con Face, debe asociar la cuenta
                        CargarProvincias();
                        setMaxLengthFields();
                        CargarDatosFacebook(oUser);
                    }
                }
            }

        }

        private void CargarDatosEnSesion(usuario user)
        {
            Session["ID"] = user.ID_Usuario;
            Session["Nombre"] = user.Nombre;
            Session["Alias"] = user.alias;
        }

        private void CargarDatosFacebook(FaceBookUser oUser)
        {
            MostrarMensaje1raVezFacebook();
            txtNombre.Text = oUser.first_name;
            txtApellido.Text = oUser.last_name;
            txtEmail.Text = oUser.email;
            txtFecNac.Value = FormatearFecha(oUser.birthday);
            ViewState["ID_Facebook"] = oUser.id;
        }

        private void MostrarMensaje1raVezFacebook()
        {
            lblmsjTitulo.Text = "Atención: ";
            lblmsjCuerpo.Text = "Por ser la primera vez que inicia sesión con Facebook, debe completar todos los datos requeridos para asociar su cuenta";
            divMensaje.Attributes["class"] = "showhide col-lg-10 col-lg-offset-1 alert-dismissible alert alert-info";
            ClientScript.RegisterStartupScript(GetType(), "mensajeshowhide", "MuestraOcultaMensaje();", true);
        }

        private void MensajeAltaOk()
        {
            lblmsjTitulo.Text = "Registración: ";
            lblmsjCuerpo.Text = "El usuario ha sido dado de alta correctamente.";
            divMensaje.Attributes["class"] = "showhide col-lg-10 col-lg-offset-1 alert-dismissible alert alert-success";
            ClientScript.RegisterStartupScript(GetType(), "mensajeshowhide", "MuestraOcultaMensaje();", true);
        }

        private string FormatearFecha(string birthday)
        {
            string fecha = birthday.Substring(6, 4) + "-" + birthday.Substring(0, 2) + "-" + birthday.Substring(3, 2);
            return Convert.ToDateTime(fecha).ToString("yyyy-MM-dd");
        }

        private static string GetFacebookUserJSON(string access_token)
        {
            string url = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name,first_name,last_name,link,birthday,cover,devices,gender", access_token);

            WebClient wc = new WebClient();
            Stream data = wc.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
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
            user.Estado = (int)EnumEstado.Activo;

            if (ViewState["ID_Facebook"] != null)
                user.ID_Facebook = Convert.ToInt64(ViewState["ID_Facebook"].ToString());

            _ctx.usuario.Add(user);
            _ctx.SaveChanges();
            limpiarCampos();
            MensajeAltaOk();
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