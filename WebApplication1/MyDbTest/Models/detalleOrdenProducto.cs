namespace MyDbTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("detalleOrdenProducto")]
    public partial class detalleOrdenProducto
    {
        public int id { get; set; }

        public int idOrden { get; set; }

        public int idProducto { get; set; }

        public virtual orden orden { get; set; }

        public virtual producto producto { get; set; }
    }
}
