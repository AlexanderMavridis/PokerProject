using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerProject.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public DateTime TournamentDate { get; set; }
        public int MinBuyIN { get; set; }
        public int MaxBuyIn { get; set; }
        ICollection<ApplicationUser> Players { get; set; }
    }
}