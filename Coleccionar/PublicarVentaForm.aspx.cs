using Coleccionar.Enums;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coleccionar
{
    public partial class PublicarVentaForm : System.Web.UI.Page
    {
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarEstadoPublicacion();
        }

        private void cargarEstadoPublicacion()
        {
            List<estado> es = _ctx.estado.Where(x => x.ID_Estado == (int)EnumEstado.Nuevo || x.ID_Estado == (int)EnumEstado.Usado || x.ID_Estado == (int)EnumEstado.Restaurado).ToList();
            es = es.OrderBy(x => x.Descripcion).ToList();
            ddlEstadoProducto.DataValueField = "ID_Estado";
            ddlEstadoProducto.DataTextField = "Descripcion";
            ddlEstadoProducto.DataSource = es;
            ddlEstadoProducto.DataBind();
        }
    }
}