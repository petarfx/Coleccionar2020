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
    
    public partial class venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public venta()
        {
            this.calificacion = new HashSet<calificacion>();
        }
    
        public int ID_Venta { get; set; }
        public int ID_Publicacion { get; set; }
        public int ID_Vendedor { get; set; }
        public int ID_Comprador { get; set; }
        public System.DateTime Fecha { get; set; }
        public byte Estado { get; set; }
        public double Importe { get; set; }
        public byte ID_TipoPago { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calificacion> calificacion { get; set; }
        public virtual estado estado1 { get; set; }
        public virtual publicacion publicacion { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual usuario usuario1 { get; set; }
        public virtual tipoPago tipoPago { get; set; }
    }
}
