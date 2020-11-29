using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Coleccionar
{
    public partial class LoggedOut : System.Web.UI.MasterPage
    {
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text.Trim();
            Response.Redirect(string.Format("BusquedaForm.aspx?filtro={0}", filtro));            
        }
    }
}