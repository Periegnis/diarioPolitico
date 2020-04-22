namespace DiarioPolitico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig18abril : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comentario", "proyecto_id", "dbo.Proyecto");
            DropIndex("dbo.Comentario", new[] { "proyecto_id" });
            AddColumn("dbo.Comentario", "proyecto", c => c.Int(nullable: false));
            DropColumn("dbo.Comentario", "proyecto_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comentario", "proyecto_id", c => c.Int());
            DropColumn("dbo.Comentario", "proyecto");
            CreateIndex("dbo.Comentario", "proyecto_id");
            AddForeignKey("dbo.Comentario", "proyecto_id", "dbo.Proyecto", "id");
        }
    }
}
