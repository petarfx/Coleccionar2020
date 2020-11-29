using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Coleccionar.Wrappers
{
    public class PublicacionesWrapper
    {
        public int ID_Publicacion { get; set; }
        public int Tipo_Publicacion { get; set; }
        public byte ID_Categoria { get; set; }
        public string ID_Categoria_Descripcion { get; set; }
        public byte ID_SubCategoria { get; set; }
        public string ID_SubCategoria_Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte Estado_Publicacion { get; set; }        
        public int ID_Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public byte Estado_Producto { get; set; }
        public string Estado_Producto_Descripcion { get; set; }
        public double Precio { get; set; }
        public int? Estado_Visibilidad { get; set; }
        public string Foto { get; set; }
    }
}