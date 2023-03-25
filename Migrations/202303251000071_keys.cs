namespace SimpleCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keys : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auths", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Auths", "Name", unique: true);
            CreateIndex("dbo.Posts", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "Title" });
            DropIndex("dbo.Auths", new[] { "Name" });
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Auths", "Name", c => c.String());
        }
    }
}
