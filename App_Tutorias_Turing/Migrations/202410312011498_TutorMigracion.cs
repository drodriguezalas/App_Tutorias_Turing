namespace App_Tutorias_Turing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TutorMigracion : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Matriculas");
        }
        
        public override void Down()
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
    }
}
