using Coleccionar.Enums;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

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
                ViewState["TipoVenta"] = EnumTipoPublicacion.Venta;
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                publicacion pub = new publicacion();
                pub.Tipo_Publicacion = Convert.ToInt32(ViewState["TipoVenta"]);
                pub.ID_Categoria = Convert.ToByte(ddlCategoria.SelectedValue);
                pub.ID_SubCategoria = Convert.ToByte(ddlSubCategoria.SelectedValue);
                pub.Nombre = txtTitulo.Text.Trim();
                pub.Descripcion = txtDescripcion.Text.Trim();
                pub.Estado_Publicacion = (int)EnumEstado.Activo;
                pub.ID_Usuario = Convert.ToInt32(Session["ID"]);
                pub.Fecha = DateTime.Now;
                pub.Estado_Producto = Convert.ToByte(ddlEstadoProducto.SelectedValue);
                pub.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
                //TODO (CUANDO SEA PUB-Busqueda va el ID del U que lo publico)
                //pub.Estado_Visibilidad = 123;
                _ctx.publicacion.Add(pub);
                _ctx.SaveChanges();

                //Obtengo el ID de la publicacion recien guardada
                int idPublicacion = pub.ID_Publicacion;

                ContentPlaceHolder content = (ContentPlaceHolder)Master.FindControl("MainContent");

                int nroImagen = 0;
                foreach (Control c in content.Controls)
                {
                    if (c.GetType() == typeof(FileUpload))
                    {
                        nroImagen++;
                        FileUpload fu = (FileUpload)c;
                        if (fu.HasFile)
                        {
                            string nombreArchivo = string.Format("{0}_{1}.jpg", idPublicacion.ToString(), nroImagen);
                            string ruta = System.Configuration.ConfigurationManager.AppSettings["pathFotosPublicaciones"].ToString() + nombreArchivo;
                            fu.SaveAs(Server.MapPath(ruta));

                            guardarFotoDB(idPublicacion, nombreArchivo);

                        }
                    }
                }
            }
        }

        private void guardarFotoDB(int idPublicacion, string nombreArchivo)
        {
            publicacionFoto pf = new publicacionFoto();
            pf.ID_Publicacion = idPublicacion;
            pf.Foto = nombreArchivo;
            _ctx.publicacionFoto.Add(pf);
            _ctx.SaveChanges();
        }

        protected void btnVenta_Click(object sender, EventArgs e)
        {
            btnVenta.CssClass = "btn btn-success activeButton";
            btnBusqueda.CssClass = "btn btn-secondary inactiveButton";
            ViewState["TipoVenta"] = EnumTipoPublicacion.Venta;
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            btnVenta.CssClass = "btn btn-secondary inactiveButton";
            btnBusqueda.CssClass = "btn btn-success activeButton";
            ViewState["TipoVenta"] = EnumTipoPublicacion.Buscado;
        }
        /*

//Funcion para guardar la Imagen

private void subirfoto()
{
try
{
string directorio = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["pathFotosCredenciales"].ToString());

string FileName = //EL ID de la pub _ JPG;  //txtDni.Text + ".Jpeg";
Draw.Image img = null;

if (hfValueImagen.Value != "")
{
  string[] array = hfValueImagen.Value.Split(',');
  byte[] dataImg = System.Convert.FromBase64String(array[1]);
  MemoryStream ms = new MemoryStream(dataImg);
  img = Draw.Image.FromStream(ms);
}

if (Directory.Exists(directorio))
{
  string archivo = directorio + FileName;

  guardarImagen(archivo, img, fuSubirFoto);
  ViewState["RutaImagen"] = string.Format(System.Configuration.ConfigurationManager.AppSettings["pathFotosCredenciales"].ToString() + "{0}", FileName);

}
hfValueImagen.Value = "";
}
catch (Exception ex)
{
throw ex;
}
}


private void guardarImagen(string nombreArchivo, Draw.Image img, FileUpload fileid)
{
try
{
if (fileid.PostedFile != null && fileid.PostedFile.ContentLength > 0)
{
  if (fileid.PostedFile.ContentLength <= (Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["tamanoMaximoImg"]) * 1024))
  {
      fileid.Width = 100;
      fileid.Height = 100;
      fileid.SaveAs(nombreArchivo);
  }
  else
  {
      throw new InvalidSizeOfImageException("La imagen que esta intentado adjuntar supera los " + System.Configuration.ConfigurationManager.AppSettings["tamanoMaximoImg"].ToString() + " Kb.");
  }
}
else
{
  img.Save(nombreArchivo, ImageFormat.Jpeg);
}
}
catch (Exception ex) { throw ex; }
}
*/


    }
}