namespace PokerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTournament : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        TournamentName = c.String(),
                        TournamentDate = c.DateTime(nullable: false),
                        MinBuyIN = c.Int(nullable: false),
                        MaxBuyIn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TournamentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tournaments");
        }
    }
}
