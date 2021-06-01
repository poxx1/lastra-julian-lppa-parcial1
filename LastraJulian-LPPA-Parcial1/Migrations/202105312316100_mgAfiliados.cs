namespace LastraJulian_LPPA_Parcial1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgAfiliados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afiliados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apellido = c.String(),
                        Nombre = c.String(),
                        Email = c.String(),
                        CUIT = c.String(),
                        Telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Afiliados");
        }
    }
}
