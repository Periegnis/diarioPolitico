namespace DiarioPolitico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proyecto2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyecto", "titulo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proyecto", "titulo");
        }
    }
}
