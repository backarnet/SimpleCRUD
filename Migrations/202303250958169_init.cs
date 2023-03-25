namespace SimpleCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Auth_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auths", t => t.Auth_Id)
                .Index(t => t.Auth_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Auth_Id", "dbo.Auths");
            DropIndex("dbo.Posts", new[] { "Auth_Id" });
            DropTable("dbo.Posts");
            DropTable("dbo.Auths");
        }
    }
}
