using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerProject.ViewModels
{
    public class ShowTourEntries
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int PlayersCount { get; set; }
        //public string PlayerId { get; set; }
    }
}