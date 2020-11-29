using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DAL;
using System.Data;
using DAL;
using Coleccionar.Wrappers;

namespace Coleccionar
{
    public partial class VerPublicacionForm : System.Web.UI.Page
    {
        ColeccionarEntities _ctx = new ColeccionarEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    cargarDatosPublicacion(Convert.ToInt32(Request.QueryString["id"]));
                }
                getrptMain();
            }
        }

        private void cargarDatosPublicacion(int idPub)
        {
            Views view = new Views();
            PublicacionesWrapper publicacion =  view.getPublicacionById(idPub);
            lblEstadoProducto.Text = publicacion.Estado_Producto_Descripcion;
            lblTitulo.Text = publicacion.Nombre;
            lblDescripcion.Text = publicacion.Descripcion;
            lblCategoriaSubCategoria.Text = string.Format("{0}/{1}", publicacion.ID_Categoria_Descripcion, publicacion.ID_SubCategoria_Descripcion);
            lblPrecio.Text = string.Format("$ {0}",publicacion.Precio.ToString());
        }

        private void getrptMain()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add();
            dummy.Rows.Add();
            rptMain.DataSource = dummy;
            rptMain.DataBind();
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptIndicators = e.Item.FindControl("rptIndicators") as Repeater;
                Repeater rptSlides = e.Item.FindControl("rptSlides") as Repeater;
                rptIndicators.DataSource = GetData();
                rptIndicators.DataBind();
                rptSlides.DataSource = GetData();
                rptSlides.DataBind();
            }
        }

        private DataTable GetData()
        {
            
            Views view = new Views();
            int idPublicacion = 1;

            List<publicacionFoto> pf = view.getPublicacionFotoById(idPublicacion);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Banner_Name"), new DataColumn("Banner_Image") });
            int c = 0;
            foreach (publicacionFoto pub in pf)
            {
                c++;
                dt.Rows.Add(c.ToString(), System.Configuration.ConfigurationManager.AppSettings["pathFotosPublicacionesPura"].ToString() + pub.Foto);
            }
            return dt;
        }


    }
}
