namespace MyDbTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mesa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mesa()
        {
            ordenMesas = new HashSet<ordenMesa>();
            reservacionMesas = new HashSet<reservacionMesa>();
        }

        public int id { get; set; }

        public int? numeroMesa { get; set; }

        public int? idStatusMesa { get; set; }

        public virtual statusMesa statusMesa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordenMesa> ordenMesas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservacionMesa> reservacionMesas { get; set; }
    }
}
