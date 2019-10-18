namespace MyDbTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("clienteFrecuente")]
    public partial class clienteFrecuente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clienteFrecuente()
        {
            ordenMesas = new HashSet<ordenMesa>();
            reservacionMesas = new HashSet<reservacionMesa>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string apellido { get; set; }

        [StringLength(50)]
        public string telefono { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public int? idDirecion { get; set; }

        public int? idCatCliente { get; set; }

        public bool? status { get; set; }

        public virtual catCliente catCliente { get; set; }

        public virtual Direccion Direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordenMesa> ordenMesas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservacionMesa> reservacionMesas { get; set; }
    }
}
