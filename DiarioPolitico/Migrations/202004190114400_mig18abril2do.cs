namespace DiarioPolitico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig18abril2do : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comentario", "like", c => c.Boolean(nullable: false));
            DropColumn("dbo.Comentario", "puntaje");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comentario", "puntaje", c => c.Int(nullable: false));
            DropColumn("dbo.Comentario", "like");
        }
    }
}
