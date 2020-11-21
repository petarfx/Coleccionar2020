using Coleccionar.Enums;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Coleccionar
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ColeccionarEntities _ctx = new ColeccionarEntities();
            var estados = _ctx.estado.ToList();
            Application["Estado"] = estados.Where(x => x.ID_Estado == (int)EnumEstado.Activo || x.ID_Estado == (int)EnumEstado.Inactivo).ToList();
            Application["EstadoProducto"] = estados.Where(x => x.ID_Estado == (int)EnumEstado.Nuevo || x.ID_Estado == (int)EnumEstado.Usado || x.ID_Estado == (int)EnumEstado.Restaurado).ToList();
            Application["EstadoVisibilidad"] = estados.Where(x => x.ID_Estado == (int)EnumEstado.Privado || x.ID_Estado == (int)EnumEstado.Publico).ToList();
            Application["EstadoEnvio"] = estados.Where(x => x.ID_Estado == (int)EnumEstado.EnvioPendiente || x.ID_Estado == (int)EnumEstado.Entregado || x.ID_Estado == (int)EnumEstado.Enviado).ToList();
        }
    }
}