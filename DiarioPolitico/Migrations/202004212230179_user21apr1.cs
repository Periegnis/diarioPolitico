namespace DiarioPolitico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user21apr1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Proyecto", "user_ci", "dbo.Usuario");
            DropIndex("dbo.Proyecto", new[] { "user_ci" });
            DropPrimaryKey("dbo.Usuario");
            AlterColumn("dbo.Proyecto", "user_ci", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Usuario", "ci", c => c.String(nullable: false, maxLength: 8));
            AddPrimaryKey("dbo.Usuario", "ci");
            CreateIndex("dbo.Proyecto", "user_ci");
            AddForeignKey("dbo.Proyecto", "user_ci", "dbo.Usuario", "ci", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyecto", "user_ci", "dbo.Usuario");
            DropIndex("dbo.Proyecto", new[] { "user_ci" });
            DropPrimaryKey("dbo.Usuario");
            AlterColumn("dbo.Usuario", "ci", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Proyecto", "user_ci", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Usuario", "ci");
            CreateIndex("dbo.Proyecto", "user_ci");
            AddForeignKey("dbo.Proyecto", "user_ci", "dbo.Usuario", "ci", cascadeDelete: true);
        }
    }
}
