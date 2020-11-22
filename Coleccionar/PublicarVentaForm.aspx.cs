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

            if (!Common.VerificaSesionActiva())
                Response.Redirect("IngresarForm.aspx");

            if (!Page.IsPostBack)
            {
                CargarEstadoPublicacion();
                CargarCategoria();
            }
        }

        private void CargarCategoria()
        {
            List<categoria> cat = new List<categoria>();
            cat = _ctx.categoria.ToList();
            cat.Add(new categoria());
            cat = cat.OrderBy(x => x.Descripcion).ToList();
            ddlCategoria.DataValueField = "ID_Categoria";
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataSource = cat;
            ddlCategoria.DataBind();
        }

        private void CargarSubCategoria(int idCat)
        {
            List<subCategoria> subc = new List<subCategoria>();
            subc = _ctx.subCategoria.Where(x => x.ID_Categoria == idCat).ToList();
            subc.Add(new subCategoria());
            subc = subc.OrderBy(x => x.Descripcion).ToList();
            ddlSubCategoria.DataValueField = "ID_SubCategoria";
            ddlSubCategoria.DataTextField = "Descripcion";
            ddlSubCategoria.DataSource = subc;
            ddlSubCategoria.DataBind();
        }

        private void CargarEstadoPublicacion()
        {
            List<estado> es = (List<estado>)Application["EstadoProducto"];

            es = es.OrderBy(x => x.Descripcion).ToList();
            ddlEstadoProducto.DataValueField = "ID_Estado";
            ddlEstadoProducto.DataTextField = "Descripcion";
            ddlEstadoProducto.DataSource = es;
            ddlEstadoProducto.DataBind();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int subC = Convert.ToInt32(ddlCategoria.SelectedValue);
            CargarSubCategoria(subC);
        }
    }
}