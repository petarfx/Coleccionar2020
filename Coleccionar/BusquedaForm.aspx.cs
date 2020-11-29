using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coleccionar.Wrappers;
using DAL;

namespace Coleccionar
{
    public partial class BusquedaForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["filtro"] != null)
                {
                    Views view = new Views();
                    //List<publicacion> publicaciones = view.getPublicaciones(Request.QueryString["filtro"].ToString());
                    List <PublicacionesWrapper> publicaciones = view.getAllPublicaciones(Request.QueryString["filtro"].ToString());
                    gvPublicaciones.DataSource = publicaciones;
                    gvPublicaciones.DataBind();
                }
            }
        }

        protected void gvPublicaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblid = (Label)e.Row.FindControl("lblid");
            if (lblid != null)
            {
                Label idFoto = (Label)e.Row.FindControl("idFoto");
                if (idFoto != null)
                {
                    Image imgFoto = (Image)e.Row.FindControl("imgFoto");
                    if (imgFoto != null)
                    {
                        string nombreArchivo = idFoto.Text;
                        string ruta = System.Configuration.ConfigurationManager.AppSettings["pathFotosPublicaciones"].ToString() + nombreArchivo;
                        imgFoto.ImageUrl = ruta;

                        
                        //imgFoto.Attributes.Add("onclick", "javascript:window.open('VerPublicacionForm.aspx','_blank','height=600px,width=600px,scrollbars=1');");
                        imgFoto.Attributes.Add("onclick", string.Format("javascript:window.location.href = 'VerPublicacionForm.aspx?id={0}';",lblid.Text));
                    }



                    //#region Seleccionar
                    //HyperLink hlSeleccionar = (HyperLink)e.Row.FindControl("hlSeleccionar");
                    //hlSeleccionar.NavigateUrl = "/ArticuloAltaForm.aspx?id=" + lblid.Text;
                    //#endregion
                }
            }
        }
    }
}