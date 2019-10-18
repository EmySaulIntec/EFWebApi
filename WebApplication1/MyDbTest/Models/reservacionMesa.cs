namespace MyDbTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reservacionMesa")]
    public partial class reservacionMesa
    {
        public int id { get; set; }

        public int? idMesa { get; set; }

        public DateTime? fecheHoraReservacion { get; set; }

        public int? idCliente { get; set; }

        public virtual clienteFrecuente clienteFrecuente { get; set; }

        public virtual mesa mesa { get; set; }
    }
}
