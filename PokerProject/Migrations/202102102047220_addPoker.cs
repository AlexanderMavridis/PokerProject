namespace PokerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPoker : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pokers",
                c => new
                    {
                        PokerId = c.Int(nullable: false, identity: true),
                        PokerVariant = c.String(),
                    })
                .PrimaryKey(t => t.PokerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pokers");
        }
    }
}
