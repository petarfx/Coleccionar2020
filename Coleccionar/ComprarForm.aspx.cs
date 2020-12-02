using DAL;
using System;
using System.Collections.Generic;
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
            CargarComboMediosDePago();
        }

        private void CargarComboMediosDePago()
        {
            List<tipoPago> tp = new List<tipoPago>();
            tp = _ctx.tipoPago.ToList();
            tp = tp.OrderBy(x => x.Descripcion).ToList();
            ddlMedioDePago.DataValueField = "ID_TipoPago";
            ddlMedioDePago.DataTextField = "Descripcion";
            ddlMedioDePago.DataSource = tp;
            ddlMedioDePago.DataBind();
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

        }
    }
}