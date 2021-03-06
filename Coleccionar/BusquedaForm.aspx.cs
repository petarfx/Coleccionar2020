﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coleccionar.Enums;
using Coleccionar.Wrappers;
using DAL;
using Image = System.Web.UI.WebControls.Image;

namespace Coleccionar
{
    public partial class BusquedaForm : System.Web.UI.Page
    {
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
            if (!Page.IsPostBack)
            {
                List<PublicacionesWrapper> publicaciones = new List<PublicacionesWrapper>();
                if (Request.QueryString["filtro"] != null)
                {
                    publicaciones = Views.getAllPublicacionesActivas(Request.QueryString["filtro"].ToString(), Convert.ToInt32(Session["ID"])).OrderByDescending(x => x.Estado_Visibilidad).ThenBy(x => x.Nombre).ThenBy(x => x.Descripcion).ToList();
                }

                if (Request.QueryString["tipopub"] != null)
                {
                    publicaciones = Views.getAllPublicacionesActivasPorEstado(Convert.ToInt32(Request.QueryString["tipopub"]), Convert.ToInt32(Session["ID"])).OrderByDescending(x => x.Estado_Visibilidad).ThenBy(x => x.Nombre).ThenBy(x => x.Descripcion).ToList();
                }
                gvPublicaciones.DataSource = publicaciones;
                gvPublicaciones.DataBind();
                setCantidad(gvPublicaciones.Rows.Count);
            }
        }

        private void setCantidad(int cant)
        {
            lblCantidad.Text = cant > 1 ? string.Format("Se han encontrado {0} productos",cant.ToString()) : cant == 1 ? string.Format("Se ha encontrado 1 producto") : "La búsqueda no arrojó ningún resultado.";
            lblCantidad.Visible = true;
            panelGrilla.Visible = cant > 0;
        }

        protected void gvPublicaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblid = (Label)e.Row.FindControl("lblid");
            if (lblid != null)
            {
                Label idFoto = (Label)e.Row.FindControl("idFoto");
                if (idFoto != null)
                {
                    var imgFoto = (Image)e.Row.FindControl("imgFoto");
                    if (imgFoto != null)
                    {
                        string nombreArchivo = idFoto.Text;
                        string ruta = System.Configuration.ConfigurationManager.AppSettings["pathFotosPublicaciones"].ToString() + nombreArchivo;
                        imgFoto.ImageUrl = ruta;


                        //imgFoto.Attributes.Add("onclick", "javascript:window.open('VerPublicacionForm.aspx','_blank','height=600px,width=600px,scrollbars=1');");
                        imgFoto.Attributes.Add("onclick", string.Format("javascript:window.location.href = 'VerPublicacionForm.aspx?id={0}';", lblid.Text));
                    }



                    //#region Seleccionar
                    //HyperLink hlSeleccionar = (HyperLink)e.Row.FindControl("hlSeleccionar");
                    //hlSeleccionar.NavigateUrl = "/ArticuloAltaForm.aspx?id=" + lblid.Text;
                    //#endregion
                }

                Label lblTipoPublicacion = (Label)e.Row.FindControl("lblTipoPublicacion");
                if (lblTipoPublicacion != null)
                {
                    if (Convert.ToInt32(lblTipoPublicacion.Text) == (int)EnumTipoPublicacion.Venta)
                        e.Row.BackColor = Color.FromArgb(207, 252, 191);
                    else
                        e.Row.BackColor = Color.FromArgb(191, 208, 252);
                }

                Label lblEstadoVisibilidad = (Label)e.Row.FindControl("lblEstadoVisibilidad");
                if (Session["ID"] != null && lblEstadoVisibilidad != null && lblEstadoVisibilidad.Text == Session["ID"].ToString())
                {
                    e.Row.CssClass = "encontradoGrilla";
                }

                Label lblPrecio = (Label)e.Row.FindControl("lblPrecio");
                if (lblPrecio != null)
                {
                    Double dprecio = Convert.ToDouble(lblPrecio.Text);
                    lblPrecio.Text = dprecio.ToString("C", CultureInfo.CurrentCulture);
                }
            }
        }
    }
}