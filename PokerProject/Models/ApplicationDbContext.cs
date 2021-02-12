using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PokerProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Poker> Pokers { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentEntry> TournamentEntries { get; set; }
        public ApplicationDbContext()
            : base("PokerProjectContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}