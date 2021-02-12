using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerProject.Models
{
    public class TournamentEntry
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public string PlayerId { get; set; }
        public ApplicationUser Player { get; set; }
        public int PlayerBuyIn { get; set; }
    }
}