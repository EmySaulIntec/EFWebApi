namespace MyDbTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ordenLlevar")]
    public partial class ordenLlevar
    {
        public int id { get; set; }

        public int? idOrden { get; set; }

        public int? idResponsable { get; set; }

        [StringLength(50)]
        public string observacion { get; set; }

        public int? idCliente { get; set; }

        public virtual orden orden { get; set; }
    }
}
