//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class mensajeria
    {
        public int ID_Mensaje { get; set; }
        public int ID_Remitente { get; set; }
        public int ID_Destinatario { get; set; }
        public int ID_Publicacion { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fecha { get; set; }
        public bool Notificacion { get; set; }
        public bool Leido { get; set; }
    
        public virtual publicacion publicacion { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual usuario usuario1 { get; set; }
    }
}
