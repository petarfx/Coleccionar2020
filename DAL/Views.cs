using Coleccionar.Wrappers;
using DAL.Wrappers;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Views
    {//where SqlMethods.Like(p.Nombre, filtro)
        private static ColeccionarEntities _ctx = new ColeccionarEntities();
        public List<publicacion> getPublicaciones(string filtro)
        {
            var query = (from p in _ctx.publicacion
                         where p.Nombre.ToLower().Contains(filtro.ToLower())
                         select p);
            return query.ToList();
        }



        public static List<PublicacionesWrapper> getAllPublicacionesActivas(string filtro, int idUsuarioLogueado)
        {
            var query = (from p in _ctx.publicacion
                         join c in _ctx.categoria
                         on p.ID_Categoria equals c.ID_Categoria
                         join s in _ctx.subCategoria
                         on p.ID_SubCategoria equals s.ID_SubCategoria
                         join e in _ctx.estado
                         on p.Estado_Producto equals e.ID_Estado
                         //join f in _ctx.publicacionFoto
                         //on p.ID_Publicacion equals f.ID_Publicacion
                         let f = _ctx.publicacionFoto.Where(x => x.ID_Publicacion == p.ID_Publicacion).FirstOrDefault()
                         where p.Estado_Publicacion == 1 && (p.Nombre.ToLower().Contains(filtro.ToLower()) || p.Descripcion.ToLower().Contains(filtro.ToLower()))
                         && p.Estado_Publicacion == 1
                        && (p.Estado_Visibilidad == null || p.Estado_Visibilidad == idUsuarioLogueado)
                         select new PublicacionesWrapper
                         {
                             ID_Publicacion = p.ID_Publicacion,
                             Tipo_Publicacion = p.Tipo_Publicacion,
                             ID_Categoria = p.ID_Categoria,
                             ID_Categoria_Descripcion = c.Descripcion,
                             ID_SubCategoria = p.ID_SubCategoria,
                             ID_SubCategoria_Descripcion = s.Descripcion,
                             Nombre = p.Nombre,
                             Descripcion = p.Descripcion,
                             Estado_Publicacion = p.Estado_Publicacion,
                             ID_Usuario = p.ID_Usuario,
                             Fecha = p.Fecha,
                             Estado_Producto = p.Estado_Producto,
                             Estado_Producto_Descripcion = e.Descripcion,
                             Precio = p.Precio,
                             Estado_Visibilidad = p.Estado_Visibilidad,
                             Foto = f.Foto
                         });

            return query.ToList();
        }

        public PublicacionesWrapper getPublicacionById(int idPub)
        {
            var query = from p in _ctx.publicacion
                        join c in _ctx.categoria
                        on p.ID_Categoria equals c.ID_Categoria
                        join s in _ctx.subCategoria
                        on p.ID_SubCategoria equals s.ID_SubCategoria
                        join e in _ctx.estado
                        on p.Estado_Producto equals e.ID_Estado
                        where p.ID_Publicacion == idPub
                        select new PublicacionesWrapper
                        {
                            ID_Publicacion = p.ID_Publicacion,
                            Tipo_Publicacion = p.Tipo_Publicacion,
                            ID_Categoria = p.ID_Categoria,
                            ID_Categoria_Descripcion = c.Descripcion,
                            ID_SubCategoria = p.ID_SubCategoria,
                            ID_SubCategoria_Descripcion = s.Descripcion,
                            Nombre = p.Nombre,
                            Descripcion = p.Descripcion,
                            Estado_Publicacion = p.Estado_Publicacion,
                            ID_Usuario = p.ID_Usuario,
                            Fecha = p.Fecha,
                            Estado_Producto = p.Estado_Producto,
                            Estado_Producto_Descripcion = e.Descripcion,
                            Precio = p.Precio,
                            Estado_Visibilidad = p.Estado_Visibilidad
                        };

            return query.FirstOrDefault();
        }

        public List<publicacionFoto> getPublicacionFotoById(int idPublicacion)
        {
            var query = (from pf in _ctx.publicacionFoto
                         where pf.ID_Publicacion == idPublicacion
                         select pf);
            return query.ToList();
        }


        public static List<PublicacionesWrapper> getAllPublicacionActivasByIdUsuario(int idUser)
        {
            var query = from p in _ctx.publicacion
                        join c in _ctx.categoria
                        on p.ID_Categoria equals c.ID_Categoria
                        join s in _ctx.subCategoria
                        on p.ID_SubCategoria equals s.ID_SubCategoria
                        join e in _ctx.estado
                        on p.Estado_Producto equals e.ID_Estado
                        let f = _ctx.publicacionFoto.Where(x => x.ID_Publicacion == p.ID_Publicacion).FirstOrDefault()
                        where p.ID_Usuario == idUser && p.Estado_Publicacion == 1
                        select new PublicacionesWrapper
                        {
                            ID_Publicacion = p.ID_Publicacion,
                            Tipo_Publicacion = p.Tipo_Publicacion,
                            ID_Categoria = p.ID_Categoria,
                            ID_Categoria_Descripcion = c.Descripcion,
                            ID_SubCategoria = p.ID_SubCategoria,
                            ID_SubCategoria_Descripcion = s.Descripcion,
                            Nombre = p.Nombre,
                            Descripcion = p.Descripcion,
                            Estado_Publicacion = p.Estado_Publicacion,
                            ID_Usuario = p.ID_Usuario,
                            Fecha = p.Fecha,
                            Estado_Producto = p.Estado_Producto,
                            Estado_Producto_Descripcion = e.Descripcion,
                            Precio = p.Precio,
                            Estado_Visibilidad = p.Estado_Visibilidad,
                            Foto = f.Foto
                        };

            return query.ToList();
        }





        public static List<PublicacionesWrapper> getAllPublicacionesActivasPorEstado(int idTipoPub, int idUsuarioLogueado)
        {
            var query = from p in _ctx.publicacion
                        join c in _ctx.categoria
                        on p.ID_Categoria equals c.ID_Categoria
                        join s in _ctx.subCategoria
                        on p.ID_SubCategoria equals s.ID_SubCategoria
                        join e in _ctx.estado
                        on p.Estado_Producto equals e.ID_Estado
                        let f = _ctx.publicacionFoto.Where(x => x.ID_Publicacion == p.ID_Publicacion).FirstOrDefault()
                        where p.Estado_Publicacion == 1 && p.Tipo_Publicacion == idTipoPub
                        && (p.Estado_Visibilidad == null || p.Estado_Visibilidad == idUsuarioLogueado)
                        select new PublicacionesWrapper
                        {
                            ID_Publicacion = p.ID_Publicacion,
                            Tipo_Publicacion = p.Tipo_Publicacion,
                            ID_Categoria = p.ID_Categoria,
                            ID_Categoria_Descripcion = c.Descripcion,
                            ID_SubCategoria = p.ID_SubCategoria,
                            ID_SubCategoria_Descripcion = s.Descripcion,
                            Nombre = p.Nombre,
                            Descripcion = p.Descripcion,
                            Estado_Publicacion = p.Estado_Publicacion,
                            ID_Usuario = p.ID_Usuario,
                            Fecha = p.Fecha,
                            Estado_Producto = p.Estado_Producto,
                            Estado_Producto_Descripcion = e.Descripcion,
                            Precio = p.Precio,
                            Estado_Visibilidad = p.Estado_Visibilidad,
                            Foto = f.Foto
                        };

            return query.ToList();
        }


        public static PublicacionesWrapper getPublicacionYFotoByIdUsuario(int idPub)
        {
            var query = from p in _ctx.publicacion
                        join c in _ctx.categoria
                        on p.ID_Categoria equals c.ID_Categoria
                        join s in _ctx.subCategoria
                        on p.ID_SubCategoria equals s.ID_SubCategoria
                        join e in _ctx.estado
                        on p.Estado_Producto equals e.ID_Estado
                        let f = _ctx.publicacionFoto.Where(x => x.ID_Publicacion == p.ID_Publicacion).FirstOrDefault()
                        where p.ID_Publicacion == idPub
                        select new PublicacionesWrapper
                        {
                            ID_Publicacion = p.ID_Publicacion,
                            Tipo_Publicacion = p.Tipo_Publicacion,
                            ID_Categoria = p.ID_Categoria,
                            ID_Categoria_Descripcion = c.Descripcion,
                            ID_SubCategoria = p.ID_SubCategoria,
                            ID_SubCategoria_Descripcion = s.Descripcion,
                            Nombre = p.Nombre,
                            Descripcion = p.Descripcion,
                            Estado_Publicacion = p.Estado_Publicacion,
                            ID_Usuario = p.ID_Usuario,
                            Fecha = p.Fecha,
                            Estado_Producto = p.Estado_Producto,
                            Estado_Producto_Descripcion = e.Descripcion,
                            Precio = p.Precio,
                            Estado_Visibilidad = p.Estado_Visibilidad,
                            Foto = f.Foto
                        };

            return query.FirstOrDefault();
        }

        public static int getCantUnreadedMessagesByUser(int IdUser)
        {
            var query = (from m in _ctx.mensajeria
                         where m.ID_Destinatario == IdUser
                         && m.Leido == false
                         select m);
            return query.Count();
        }

        public static List<MensajesWrapper> getAllUnreadedMessagesByUsuario(int IdUser)
        {
            var query = from m in _ctx.mensajeria
                        join u in _ctx.usuario
                        on m.ID_Remitente equals u.ID_Usuario
                        //join prod in _ctx.provincia
                        //on u.Domicilio_ID_Provincia equals prod.ID_Provincia
                        //join loc in _ctx.localidad
                        //on u.Domicilio_ID_Localidad equals loc.ID_Localidad
                        join p in _ctx.publicacion
                        on m.ID_Publicacion equals p.ID_Publicacion
                        where m.ID_Destinatario == IdUser

                        select new MensajesWrapper
                        {
                            ID_Mensaje = m.ID_Mensaje,
                            ID_Remitente = u.ID_Usuario,
                            Remitente_Alias = u.alias,
                            Remitente_Email = u.Email,
                            
                            //Remitente_Provincia_Descripcion = prod.Descripcion,
                            //Remitente_Localidad_Descripcion = loc.Descripcion,
                            //Remitente_Calle_Descripcion = u.Domicilio_Calle,
                            //Remitente_Numero_Calle = u.Domicilio_Nro,
                            //Remitente_Piso = u.Domicilio_Piso,
                            //Remitente_Depto = u.Domicilio_Depto.ToString(),

                            Remitente_Celular = u.Celular,
                            Remitente_Telefono = u.Telefono,
                            ID_Destinatario = m.ID_Destinatario,
                            ID_Publicacion = m.ID_Publicacion,
                            Publicacion_Nombre = p.Nombre,
                            Descripcion = m.Descripcion,
                            Fecha = m.Fecha,
                            Notificacion = m.Notificacion,
                            Leido = m.Leido
                        };
            return query.ToList();
        }

        public static MensajesWrapper getMessageByIdMensaje(int IdMensaje)
        {
            var query = from m in _ctx.mensajeria
                        join u in _ctx.usuario
                        on m.ID_Remitente equals u.ID_Usuario
                        join prov in _ctx.provincia
                        on u.Domicilio_ID_Provincia equals prov.ID_Provincia
                        join loc in _ctx.localidad
                        on u.Domicilio_ID_Localidad equals loc.ID_Localidad
                        join p in _ctx.publicacion
                        on m.ID_Publicacion equals p.ID_Publicacion
                        where m.ID_Mensaje == IdMensaje
                        select new MensajesWrapper
                        {
                            ID_Mensaje = m.ID_Mensaje,
                            ID_Remitente = u.ID_Usuario,
                            Remitente_Alias = u.alias,
                            Remitente_Email = u.Email,
                            Remitente_Direccion = prov.Descripcion + " " + loc.Descripcion + " " + u.Domicilio_Calle + " " + u.Domicilio_Nro + " " + u.Domicilio_Piso + u.Domicilio_Depto,
                            Remitente_Celular = u.Celular,
                            Remitente_Telefono = u.Telefono,
                            ID_Destinatario = m.ID_Destinatario,
                            ID_Publicacion = m.ID_Publicacion,
                            Publicacion_Nombre = p.Nombre,
                            Descripcion = m.Descripcion,
                            Fecha = m.Fecha,
                            Notificacion = m.Notificacion,
                            Leido = m.Leido,

                            Remitente_Provincia_Descripcion = prov.Descripcion,
                            Remitente_Localidad_Descripcion = loc.Descripcion,
                            Remitente_Calle_Descripcion = u.Domicilio_Calle,
                            Remitente_Numero_Calle = u.Domicilio_Nro,
                            Remitente_Piso = u.Domicilio_Piso,
                            Remitente_Depto = u.Domicilio_Depto
                        };
            return query.FirstOrDefault();
        }












        public static PublicacionesWrapper getPublicacionDatosByIdUsuario(int idPub)
        {
            var query = from p in _ctx.publicacion
                        join c in _ctx.categoria
                        on p.ID_Categoria equals c.ID_Categoria
                        join s in _ctx.subCategoria
                        on p.ID_SubCategoria equals s.ID_SubCategoria
                        join e in _ctx.estado
                        on p.Estado_Producto equals e.ID_Estado
                        join u in _ctx.usuario
                        on p.ID_Usuario equals u.ID_Usuario
                        where p.ID_Publicacion == idPub
                        select new PublicacionesWrapper
                        {
                            ID_Publicacion = p.ID_Publicacion,
                            Tipo_Publicacion = p.Tipo_Publicacion,
                            ID_Categoria = p.ID_Categoria,
                            ID_Categoria_Descripcion = c.Descripcion,
                            ID_SubCategoria = p.ID_SubCategoria,
                            ID_SubCategoria_Descripcion = s.Descripcion,
                            Nombre = p.Nombre,
                            Descripcion = p.Descripcion,
                            Estado_Publicacion = p.Estado_Publicacion,
                            ID_Usuario = p.ID_Usuario,
                            Fecha = p.Fecha,
                            Estado_Producto = p.Estado_Producto,
                            Estado_Producto_Descripcion = e.Descripcion,
                            Precio = p.Precio,
                            Estado_Visibilidad = p.Estado_Visibilidad,
                            UsuarioAlias = u.alias
                        };

            return query.FirstOrDefault();
        }
    }
}
