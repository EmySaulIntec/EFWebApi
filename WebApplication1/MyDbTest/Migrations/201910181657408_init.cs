namespace MyDbTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.catCliente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Categoria = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.clienteFrecuente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50, unicode: false),
                        apellido = c.String(maxLength: 50, unicode: false),
                        telefono = c.String(maxLength: 50, unicode: false),
                        email = c.String(maxLength: 50, unicode: false),
                        idDirecion = c.Int(),
                        idCatCliente = c.Int(),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Direccion", t => t.idDirecion)
                .ForeignKey("dbo.catCliente", t => t.idCatCliente)
                .Index(t => t.idDirecion)
                .Index(t => t.idCatCliente);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numero = c.String(maxLength: 50, unicode: false),
                        calle = c.String(maxLength: 50, unicode: false),
                        colonia = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ordenMesa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idOrden = c.Int(nullable: false),
                        idMesa = c.Int(nullable: false),
                        idCliente = c.Int(nullable: false),
                        idPersonal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.mesas", t => t.idMesa)
                .ForeignKey("dbo.orden", t => t.idOrden)
                .ForeignKey("dbo.Usuarios", t => t.idPersonal)
                .ForeignKey("dbo.clienteFrecuente", t => t.idCliente)
                .Index(t => t.idOrden)
                .Index(t => t.idMesa)
                .Index(t => t.idCliente)
                .Index(t => t.idPersonal);
            
            CreateTable(
                "dbo.mesas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numeroMesa = c.Int(),
                        idStatusMesa = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.statusMesa", t => t.idStatusMesa)
                .Index(t => t.idStatusMesa);
            
            CreateTable(
                "dbo.reservacionMesa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idMesa = c.Int(),
                        fecheHoraReservacion = c.DateTime(),
                        idCliente = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.mesas", t => t.idMesa)
                .ForeignKey("dbo.clienteFrecuente", t => t.idCliente)
                .Index(t => t.idMesa)
                .Index(t => t.idCliente);
            
            CreateTable(
                "dbo.statusMesa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.orden",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        monto = c.Int(),
                        Fechaa = c.DateTime(),
                        status = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.detalleOrdenProducto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idOrden = c.Int(nullable: false),
                        idProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.producto", t => t.idProducto)
                .ForeignKey("dbo.orden", t => t.idOrden)
                .Index(t => t.idOrden)
                .Index(t => t.idProducto);
            
            CreateTable(
                "dbo.producto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(maxLength: 50, unicode: false),
                        Descripcion = c.String(maxLength: 50, unicode: false),
                        Precio = c.Int(),
                        idCategoriaProducto = c.Int(nullable: false),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.catProducto", t => t.idCategoriaProducto)
                .Index(t => t.idCategoriaProducto);
            
            CreateTable(
                "dbo.catProducto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        categoria = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.detalleProductoIngrediente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idProducto = c.Int(nullable: false),
                        idIngrediente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Ingredientes", t => t.idIngrediente)
                .ForeignKey("dbo.producto", t => t.idProducto)
                .Index(t => t.idProducto)
                .Index(t => t.idIngrediente);
            
            CreateTable(
                "dbo.Ingredientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        stock = c.Int(),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ordenLlevar",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idOrden = c.Int(),
                        idResponsable = c.Int(),
                        observacion = c.String(maxLength: 50, unicode: false),
                        idCliente = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.orden", t => t.idOrden)
                .Index(t => t.idOrden);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50, unicode: false),
                        apellido = c.String(maxLength: 50, unicode: false),
                        idRol = c.Int(nullable: false),
                        status = c.Boolean(),
                        password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.rol", t => t.idRol)
                .Index(t => t.idRol);
            
            CreateTable(
                "dbo.rol",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Rol = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.clienteFrecuente", "idCatCliente", "dbo.catCliente");
            DropForeignKey("dbo.reservacionMesa", "idCliente", "dbo.clienteFrecuente");
            DropForeignKey("dbo.ordenMesa", "idCliente", "dbo.clienteFrecuente");
            DropForeignKey("dbo.Usuarios", "idRol", "dbo.rol");
            DropForeignKey("dbo.ordenMesa", "idPersonal", "dbo.Usuarios");
            DropForeignKey("dbo.ordenMesa", "idOrden", "dbo.orden");
            DropForeignKey("dbo.ordenLlevar", "idOrden", "dbo.orden");
            DropForeignKey("dbo.detalleOrdenProducto", "idOrden", "dbo.orden");
            DropForeignKey("dbo.detalleProductoIngrediente", "idProducto", "dbo.producto");
            DropForeignKey("dbo.detalleProductoIngrediente", "idIngrediente", "dbo.Ingredientes");
            DropForeignKey("dbo.detalleOrdenProducto", "idProducto", "dbo.producto");
            DropForeignKey("dbo.producto", "idCategoriaProducto", "dbo.catProducto");
            DropForeignKey("dbo.mesas", "idStatusMesa", "dbo.statusMesa");
            DropForeignKey("dbo.reservacionMesa", "idMesa", "dbo.mesas");
            DropForeignKey("dbo.ordenMesa", "idMesa", "dbo.mesas");
            DropForeignKey("dbo.clienteFrecuente", "idDirecion", "dbo.Direccion");
            DropIndex("dbo.Usuarios", new[] { "idRol" });
            DropIndex("dbo.ordenLlevar", new[] { "idOrden" });
            DropIndex("dbo.detalleProductoIngrediente", new[] { "idIngrediente" });
            DropIndex("dbo.detalleProductoIngrediente", new[] { "idProducto" });
            DropIndex("dbo.producto", new[] { "idCategoriaProducto" });
            DropIndex("dbo.detalleOrdenProducto", new[] { "idProducto" });
            DropIndex("dbo.detalleOrdenProducto", new[] { "idOrden" });
            DropIndex("dbo.reservacionMesa", new[] { "idCliente" });
            DropIndex("dbo.reservacionMesa", new[] { "idMesa" });
            DropIndex("dbo.mesas", new[] { "idStatusMesa" });
            DropIndex("dbo.ordenMesa", new[] { "idPersonal" });
            DropIndex("dbo.ordenMesa", new[] { "idCliente" });
            DropIndex("dbo.ordenMesa", new[] { "idMesa" });
            DropIndex("dbo.ordenMesa", new[] { "idOrden" });
            DropIndex("dbo.clienteFrecuente", new[] { "idCatCliente" });
            DropIndex("dbo.clienteFrecuente", new[] { "idDirecion" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.rol");
            DropTable("dbo.Usuarios");
            DropTable("dbo.ordenLlevar");
            DropTable("dbo.Ingredientes");
            DropTable("dbo.detalleProductoIngrediente");
            DropTable("dbo.catProducto");
            DropTable("dbo.producto");
            DropTable("dbo.detalleOrdenProducto");
            DropTable("dbo.orden");
            DropTable("dbo.statusMesa");
            DropTable("dbo.reservacionMesa");
            DropTable("dbo.mesas");
            DropTable("dbo.ordenMesa");
            DropTable("dbo.Direccion");
            DropTable("dbo.clienteFrecuente");
            DropTable("dbo.catCliente");
        }
    }
}
