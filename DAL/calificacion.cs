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
    
    public partial class calificacion
    {
        public int ID_Calificacion { get; set; }
        public int ID_Venta { get; set; }
        public int ID_Usuario { get; set; }
        public byte Calificacion1 { get; set; }
    
        public virtual venta venta { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
