namespace relaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Edad = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        Departamento_IdDepartamento = c.Int(),
                    })
                .PrimaryKey(t => t.IdCliente)
                .ForeignKey("dbo.Departamentoes", t => t.Departamento_IdDepartamento)
                .Index(t => t.Departamento_IdDepartamento);
            
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        IdDepartamento = c.Int(nullable: false, identity: true),
                        NombreDepartamento = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdDepartamento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "Departamento_IdDepartamento", "dbo.Departamentoes");
            DropIndex("dbo.Clientes", new[] { "Departamento_IdDepartamento" });
            DropTable("dbo.Departamentoes");
            DropTable("dbo.Clientes");
        }
    }
}
