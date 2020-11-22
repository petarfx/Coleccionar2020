using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Coleccionar
{
    public partial class IngresarForm : Page
    {
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Common.VerificaSesionActiva())
                Response.Redirect("IngresarForm.aspx");
        }

        #region Private Methods
        private void CargarDatosEnSesion(usuario user)
        {
            Session["ID"] = user.ID_Usuario;
            Session["Nombre"] = user.Nombre;
            Session["Alias"] = user.alias;            
        }

        private bool ValidaContraseña(string v1, string v2)
        {
            return v1 == v2;
        }
        #endregion

        #region Eventos

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                ColeccionarEntities ctx = new ColeccionarEntities();

                string txtuser = txtAlias.Text.Trim();
                string txtpass = Encriptar.Encrypt(txtPassword.Text.Trim());
                usuario user = ctx.usuario.Where(x => x.alias == txtuser && x.Clave == txtpass).FirstOrDefault();

                if (user != null)
                {
                    if (ValidaContraseña(txtpass, user.Clave))
                    {
                        CargarDatosEnSesion(user);
                        FormsAuthentication.RedirectFromLoginPage("A", false);
                    }
                    else
                    {
                        //contraseña incorrecta
                    }
                }
            }
        }
        #endregion
    }
}
