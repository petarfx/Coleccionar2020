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
using Coleccionar.Enums;
using System.Globalization;

namespace Coleccionar
{
    public partial class VerPublicacionForm : System.Web.UI.Page
    {
        ColeccionarEntities _ctx = new ColeccionarEntities();
        void Page_PreInit(Object sender, EventArgs e)
        {
            setMasterPage();
        }
        private void setMasterPage()
        {
            this.MasterPageFile = !Common.VerificaSesionActiva() ? "~/LoggedOut.Master" : "~/LoggedIn.Master";
        }

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
            //lblPrecio.Text = string.Format("$ {0}",publicacion.Precio.ToString());
            lblPrecio.Text = publicacion.Precio.ToString("C", CultureInfo.CurrentCulture);
            lblTipoPublicacion.Text = " - " + Helper.getTipoPublicacionById(publicacion.Tipo_Publicacion);
            lblFecha.Text = Helper.getFechaPublicacion(publicacion.Fecha);

            ViewState["TipoPublicacion"] = publicacion.Tipo_Publicacion;
            if ((int)ViewState["TipoPublicacion"] == (int)EnumTipoPublicacion.Buscado)
            {
                btnComprar.Text = "¡LO TENGO!";
                ViewState["ID_Publicacion"] = publicacion.ID_Publicacion;
            }
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
            int idPublicacion = Convert.ToInt32(Request.QueryString["id"]);

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

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            if ((int)ViewState["TipoPublicacion"] == (int)EnumTipoPublicacion.Venta)
            {//Venta

            }
            else
            {//¡Lo tengo!
                lblLoTengoMsj.Text = string.Format("Felicitaciones! Eres el propietario de un objeto buscado! El siguiente paso es la creacion de la publicacion, la cual sera exclusiva para la persona interesada por una semana, de no concretarse la busqueda, la publicacion pasara a estado publica... Deseas continuar?");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { openLoTengoModal(); });", true);
            }
        }


        protected void btnLoTengo_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = ViewState["ID_Publicacion"].ToString();
                Response.Redirect(string.Format("LoTengoForm.aspx?idpu={0}", filtro),false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
