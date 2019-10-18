namespace MyDbTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ordenMesa")]
    public partial class ordenMesa
    {
        public int id { get; set; }

        public int idOrden { get; set; }

        public int idMesa { get; set; }

        public int idCliente { get; set; }

        public int idPersonal { get; set; }

        public virtual clienteFrecuente clienteFrecuente { get; set; }

        public virtual mesa mesa { get; set; }

        public virtual orden orden { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
