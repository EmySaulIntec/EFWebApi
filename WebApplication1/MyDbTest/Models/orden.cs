namespace MyDbTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("orden")]
    public partial class orden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public orden()
        {
            detalleOrdenProductoes = new HashSet<detalleOrdenProducto>();
            ordenLlevars = new HashSet<ordenLlevar>();
            ordenMesas = new HashSet<ordenMesa>();
        }

        public int id { get; set; }

        public int? monto { get; set; }

        public DateTime? Fechaa { get; set; }

        public int? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleOrdenProducto> detalleOrdenProductoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordenLlevar> ordenLlevars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordenMesa> ordenMesas { get; set; }
    }
}
