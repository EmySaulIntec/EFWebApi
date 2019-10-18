namespace MyDbTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("detalleProductoIngrediente")]
    public partial class detalleProductoIngrediente
    {
        public int id { get; set; }

        public int idProducto { get; set; }

        public int idIngrediente { get; set; }

        public virtual Ingrediente Ingrediente { get; set; }

        public virtual producto producto { get; set; }
    }
}
