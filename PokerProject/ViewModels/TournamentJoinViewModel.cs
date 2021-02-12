using PokerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerProject.ViewModels
{
    public class TournamentJoinViewModel
    {
        public Tournament Tournament { get; set; }
        public int PlayerBuyIn { get; set; }
    }
}