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
    
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.calificacion = new HashSet<calificacion>();
            this.encontrado = new HashSet<encontrado>();
            this.venta = new HashSet<venta>();
            this.venta1 = new HashSet<venta>();
            this.mensajeria = new HashSet<mensajeria>();
            this.mensajeria1 = new HashSet<mensajeria>();
        }
    
        public int ID_Usuario { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public System.DateTime Fecha_Nac { get; set; }
        public decimal Domicilio_Lat { get; set; }
        public decimal Domicilio_Lon { get; set; }
        public string Domicilio_Calle { get; set; }
        public int Domicilio_ID_Provincia { get; set; }
        public int Domicilio_ID_Localidad { get; set; }
        public Nullable<int> Domicilio_Nro { get; set; }
        public Nullable<int> Domicilio_Piso { get; set; }
        public string Domicilio_Depto { get; set; }
        public Nullable<int> Celular { get; set; }
        public string Email { get; set; }
        public Nullable<long> ID_Facebook { get; set; }
        public byte Estado { get; set; }
        public string alias { get; set; }
        public int ID_Avatar { get; set; }
        public Nullable<long> Telefono { get; set; }
        public string Clave { get; set; }
    
        public virtual avatar avatar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calificacion> calificacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<encontrado> encontrado { get; set; }
        public virtual localidad localidad { get; set; }
        public virtual provincia provincia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<venta> venta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<venta> venta1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mensajeria> mensajeria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mensajeria> mensajeria1 { get; set; }
    }
}
