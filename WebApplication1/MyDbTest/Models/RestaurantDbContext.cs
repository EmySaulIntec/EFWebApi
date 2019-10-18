namespace MyDbTest.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
            : base("name=RestaurantDbContext")
        {
        }

        public virtual DbSet<catCliente> catClientes { get; set; }
        public virtual DbSet<catProducto> catProductoes { get; set; }
        public virtual DbSet<clienteFrecuente> clienteFrecuentes { get; set; }
        public virtual DbSet<detalleOrdenProducto> detalleOrdenProductoes { get; set; }
        public virtual DbSet<detalleProductoIngrediente> detalleProductoIngredientes { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Ingrediente> Ingredientes { get; set; }
        public virtual DbSet<mesa> mesas { get; set; }
        public virtual DbSet<orden> ordens { get; set; }
        public virtual DbSet<ordenLlevar> ordenLlevars { get; set; }
        public virtual DbSet<ordenMesa> ordenMesas { get; set; }
        public virtual DbSet<producto> productoes { get; set; }
        public virtual DbSet<reservacionMesa> reservacionMesas { get; set; }
        public virtual DbSet<rol> rols { get; set; }
        public virtual DbSet<statusMesa> statusMesas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<catCliente>()
                .Property(e => e.Categoria)
                .IsUnicode(false);

            modelBuilder.Entity<catCliente>()
                .HasMany(e => e.clienteFrecuentes)
                .WithOptional(e => e.catCliente)
                .HasForeignKey(e => e.idCatCliente);

            modelBuilder.Entity<catProducto>()
                .Property(e => e.categoria)
                .IsUnicode(false);

            modelBuilder.Entity<catProducto>()
                .HasMany(e => e.productoes)
                .WithRequired(e => e.catProducto)
                .HasForeignKey(e => e.idCategoriaProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<clienteFrecuente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<clienteFrecuente>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<clienteFrecuente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<clienteFrecuente>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<clienteFrecuente>()
                .HasMany(e => e.ordenMesas)
                .WithRequired(e => e.clienteFrecuente)
                .HasForeignKey(e => e.idCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<clienteFrecuente>()
                .HasMany(e => e.reservacionMesas)
                .WithOptional(e => e.clienteFrecuente)
                .HasForeignKey(e => e.idCliente);

            modelBuilder.Entity<Direccion>()
                .Property(e => e.numero)
                .IsUnicode(false);

            modelBuilder.Entity<Direccion>()
                .Property(e => e.calle)
                .IsUnicode(false);

            modelBuilder.Entity<Direccion>()
                .Property(e => e.colonia)
                .IsUnicode(false);

            modelBuilder.Entity<Direccion>()
                .HasMany(e => e.clienteFrecuentes)
                .WithOptional(e => e.Direccion)
                .HasForeignKey(e => e.idDirecion);

            modelBuilder.Entity<Ingrediente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ingrediente>()
                .HasMany(e => e.detalleProductoIngredientes)
                .WithRequired(e => e.Ingrediente)
                .HasForeignKey(e => e.idIngrediente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mesa>()
                .HasMany(e => e.ordenMesas)
                .WithRequired(e => e.mesa)
                .HasForeignKey(e => e.idMesa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mesa>()
                .HasMany(e => e.reservacionMesas)
                .WithOptional(e => e.mesa)
                .HasForeignKey(e => e.idMesa);

            modelBuilder.Entity<orden>()
                .HasMany(e => e.detalleOrdenProductoes)
                .WithRequired(e => e.orden)
                .HasForeignKey(e => e.idOrden)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<orden>()
                .HasMany(e => e.ordenLlevars)
                .WithOptional(e => e.orden)
                .HasForeignKey(e => e.idOrden);

            modelBuilder.Entity<orden>()
                .HasMany(e => e.ordenMesas)
                .WithRequired(e => e.orden)
                .HasForeignKey(e => e.idOrden)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ordenLlevar>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .HasMany(e => e.detalleOrdenProductoes)
                .WithRequired(e => e.producto)
                .HasForeignKey(e => e.idProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<producto>()
                .HasMany(e => e.detalleProductoIngredientes)
                .WithRequired(e => e.producto)
                .HasForeignKey(e => e.idProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rol>()
                .Property(e => e.Rol1)
                .IsUnicode(false);

            modelBuilder.Entity<rol>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.rol)
                .HasForeignKey(e => e.idRol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<statusMesa>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<statusMesa>()
                .HasMany(e => e.mesas)
                .WithOptional(e => e.statusMesa)
                .HasForeignKey(e => e.idStatusMesa);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.ordenMesas)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idPersonal)
                .WillCascadeOnDelete(false);
        }
    }
}
