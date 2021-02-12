namespace PokerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTournamentEntry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TournamentEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentId = c.Int(nullable: false),
                        PlayerId = c.String(maxLength: 128),
                        PlayerBuyIn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PlayerId)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .Index(t => t.TournamentId)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentEntries", "TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.TournamentEntries", "PlayerId", "dbo.AspNetUsers");
            DropIndex("dbo.TournamentEntries", new[] { "PlayerId" });
            DropIndex("dbo.TournamentEntries", new[] { "TournamentId" });
            DropTable("dbo.TournamentEntries");
        }
    }
}
