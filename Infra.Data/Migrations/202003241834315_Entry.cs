namespace Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        Desc = c.String(),
                        IsExpense = c.Boolean(nullable: false),
                        value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EntryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Entries");
        }
    }
}
