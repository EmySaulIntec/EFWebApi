namespace MyDbTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Direccion")]
    public partial class Direccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direccion()
        {
            clienteFrecuentes = new HashSet<clienteFrecuente>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string numero { get; set; }

        [StringLength(50)]
        public string calle { get; set; }

        [StringLength(50)]
        public string colonia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clienteFrecuente> clienteFrecuentes { get; set; }
    }
}
