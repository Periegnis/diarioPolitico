namespace DiarioPolitico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cero : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comentario = c.String(nullable: false),
                        puntaje = c.Int(nullable: false),
                        proyecto_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Proyecto", t => t.proyecto_id, cascadeDelete: true)
                .Index(t => t.proyecto_id);
            
            CreateTable(
                "dbo.Proyecto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        texto = c.String(nullable: false),
                        user_ci = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuario", t => t.user_ci, cascadeDelete: true)
                .Index(t => t.user_ci);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        ci = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        isAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ci);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentario", "proyecto_id", "dbo.Proyecto");
            DropForeignKey("dbo.Proyecto", "user_ci", "dbo.Usuario");
            DropIndex("dbo.Proyecto", new[] { "user_ci" });
            DropIndex("dbo.Comentario", new[] { "proyecto_id" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Proyecto");
            DropTable("dbo.Comentario");
        }
    }
}
