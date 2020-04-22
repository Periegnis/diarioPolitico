namespace DiarioPolitico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comentario3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comentario", "proyecto_id", "dbo.Proyecto");
            DropIndex("dbo.Comentario", new[] { "proyecto_id" });
            AlterColumn("dbo.Comentario", "proyecto_id", c => c.Int());
            CreateIndex("dbo.Comentario", "proyecto_id");
            AddForeignKey("dbo.Comentario", "proyecto_id", "dbo.Proyecto", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentario", "proyecto_id", "dbo.Proyecto");
            DropIndex("dbo.Comentario", new[] { "proyecto_id" });
            AlterColumn("dbo.Comentario", "proyecto_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Comentario", "proyecto_id");
            AddForeignKey("dbo.Comentario", "proyecto_id", "dbo.Proyecto", "id", cascadeDelete: true);
        }
    }
}
