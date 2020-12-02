using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coleccionar.Enums;
using DAL;

namespace Coleccionar
{
    public partial class LoTengoForm : System.Web.UI.Page
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
                CargarDatosPublicacionOriginal();
            }
        }

        private void CargarDatosPublicacionOriginal()
        {
            publicacion pub = _ctx.publicacion.Find(Convert.ToInt32(Request.QueryString["idpu"]));
            ddlCategoria.SelectedValue = pub.ID_Categoria.ToString();
            CargarSubCategoria(pub.ID_Categoria);
            ddlSubCategoria.SelectedValue = pub.ID_SubCategoria.ToString();
            txtTitulo.Text = pub.Nombre;
            txtPrecio.Text = pub.Precio.ToString();
            ViewState["idUserPubOrig"] = pub.ID_Usuario;
            ViewState["NombrePub"] = pub.Nombre;
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
                if (validaFotos())
                {
                    publicacion pub = new publicacion();
                    pub.Tipo_Publicacion = (int)EnumTipoPublicacion.Venta;
                    pub.ID_Categoria = Convert.ToByte(ddlCategoria.SelectedValue);
                    pub.ID_SubCategoria = Convert.ToByte(ddlSubCategoria.SelectedValue);
                    pub.Nombre = txtTitulo.Text.Trim();
                    pub.Descripcion = txtDescripcion.Text.Trim();
                    pub.Estado_Publicacion = (int)EnumEstado.Activo;
                    pub.ID_Usuario = Convert.ToInt32(Session["ID"]);
                    pub.Fecha = DateTime.Now;
                    pub.Estado_Producto = Convert.ToByte(ddlEstadoProducto.SelectedValue);
                    pub.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
                    pub.Estado_Visibilidad = Convert.ToInt32(ViewState["idUserPubOrig"]);
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

                    //Enviar Mensaje
                    mensajeria msj = new mensajeria();
                    msj.ID_Publicacion = Convert.ToInt32(Request.QueryString["idpu"]);
                    msj.ID_Remitente = Convert.ToInt32(Session["ID"]);
                    msj.ID_Destinatario = Convert.ToInt32(ViewState["idUserPubOrig"]);
                    msj.Descripcion = string.Format("¡Encontraron tu producto!!, El producto {0} fue encontrado por {1}, tendrás una semana de exclusividad sobre esa publicación, de no concretarse la compra, la misma pasará a estado publica.", ViewState["NombrePub"].ToString(), Session["Nombre"].ToString());
                    msj.Fecha = DateTime.Now;
                    msj.Notificacion = true;
                    msj.Leido = false;
                    _ctx.mensajeria.Add(msj);
                    _ctx.SaveChanges();

                    Response.Redirect("Default.aspx");
                }
                else
                {
                    //faltan las fotos
                }
            }
        }

        private bool validaFotos()
        {
            return FileUpload1.HasFile || FileUpload2.HasFile || FileUpload3.HasFile || FileUpload4.HasFile || FileUpload5.HasFile || FileUpload6.HasFile;
        }

        private void guardarFotoDB(int idPublicacion, string nombreArchivo)
        {
            publicacionFoto pf = new publicacionFoto();
            pf.ID_Publicacion = idPublicacion;
            pf.Foto = nombreArchivo;
            _ctx.publicacionFoto.Add(pf);
            _ctx.SaveChanges();
        }
    }
}