namespace App_Tutorias_Turing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreDeLaMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        TutoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Matriculas");
        }
    }
}
