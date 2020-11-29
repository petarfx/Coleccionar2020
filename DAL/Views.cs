using Coleccionar.Wrappers;
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
        private ColeccionarEntities _ctx = new ColeccionarEntities();
        public List<publicacion> getPublicaciones(string filtro)
        {
            var query = (from p in _ctx.publicacion
                         where p.Nombre.ToLower().Contains(filtro.ToLower())
                         select p);
            return query.ToList();
        }



        public List<PublicacionesWrapper> getAllPublicaciones(string filtro)
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
                         where p.Nombre.ToLower().Contains(filtro.ToLower())
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
    }
}
