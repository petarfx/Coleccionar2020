﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ColeccionarEntities : DbContext
    {
        public ColeccionarEntities()
            : base("name=ColeccionarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<calificacion> calificacion { get; set; }
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<encontrado> encontrado { get; set; }
        public virtual DbSet<estado> estado { get; set; }
        public virtual DbSet<localidad> localidad { get; set; }
        public virtual DbSet<mensajeria> mensajeria { get; set; }
        public virtual DbSet<provincia> provincia { get; set; }
        public virtual DbSet<publicacion> publicacion { get; set; }
        public virtual DbSet<publicacionFoto> publicacionFoto { get; set; }
        public virtual DbSet<subCategoria> subCategoria { get; set; }
        public virtual DbSet<venta> venta { get; set; }
        public virtual DbSet<avatar> avatar { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<tipoPago> tipoPago { get; set; }
    }
}
