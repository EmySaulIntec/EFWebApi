namespace MyDbTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("producto")]
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            detalleOrdenProductoes = new HashSet<detalleOrdenProducto>();
            detalleProductoIngredientes = new HashSet<detalleProductoIngrediente>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public int? Precio { get; set; }

        public int idCategoriaProducto { get; set; }

        public bool? status { get; set; }

        public virtual catProducto catProducto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleOrdenProducto> detalleOrdenProductoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleProductoIngrediente> detalleProductoIngredientes { get; set; }
    }
}
