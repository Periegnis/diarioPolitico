namespace DiarioPolitico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cero1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Noticia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                        descripcion = c.String(),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Noticia");
        }
    }
}
