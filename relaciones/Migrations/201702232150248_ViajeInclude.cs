namespace relaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViajeInclude : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Viajes",
                c => new
                    {
                        IdViaje = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        Vendio = c.String(nullable: false, maxLength: 50),
                        Cobro = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdViaje)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .Index(t => t.IdCliente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viajes", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Viajes", new[] { "IdCliente" });
            DropTable("dbo.Viajes");
        }
    }
}
