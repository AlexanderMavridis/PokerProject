using Microsoft.AspNet.Identity;
using PokerProject.Models;
using PokerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokerProject.Controllers
{
    public class TournamentController : Controller
    {
        private ApplicationDbContext context;

        public TournamentController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Tournament
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowEntriesPerTour()
        {

            var query = from t in context.TournamentEntries
                        group t by t.TournamentId into idgroup
                        select new ShowTourEntries()
                        {
                            TournamentId = idgroup.Key,
                            PlayersCount = idgroup.Count()
                        };


            return View(query.ToList());
        }

        [Authorize]
        public ActionResult JoinTournament(int id)
        {
            var tour = context.Tournaments.SingleOrDefault(t => t.TournamentId == id);
            if (tour == null)
                return HttpNotFound();
            var tournamentEntry = new TournamentJoinViewModel
            {
                Tournament = tour
            };

            return View(tournamentEntry);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Join(TournamentJoinViewModel viewmodel)
        {
            var userId = User.Identity.GetUserId();
            var entry = new TournamentEntry
            {
                TournamentId = viewmodel.Tournament.TournamentId,
                PlayerId = userId,
                PlayerBuyIn = viewmodel.PlayerBuyIn
            };

            context.TournamentEntries.Add(entry);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowTournaments()
        {
            var tournaments = context.Tournaments.ToList();
            return View(tournaments);
        }

        [Authorize]
        public ActionResult DeleteTournament(int id)
        {
            var tour = context.Tournaments.SingleOrDefault(t => t.TournamentId == id);
            if (tour == null)
                return HttpNotFound();

            context.Tournaments.Remove(tour);
            context.SaveChanges();

            return RedirectToAction("ShowTournaments");
        }

        [Authorize]
        public ActionResult EditTournament(int id)
        {
            var tour = context.Tournaments.SingleOrDefault(t => t.TournamentId == id);
            if (tour == null)
                return HttpNotFound();

            return View("EditTournament", tour);
        }

        [Authorize]
        public ActionResult Edit(Tournament tournament)
        {
            var tour = context.Tournaments.SingleOrDefault(t => t.TournamentId == tournament.TournamentId);

            if (tour == null)
                return HttpNotFound();

            tour.TournamentName = tournament.TournamentName;
            tour.TournamentDate = tournament.TournamentDate;
            tour.MaxBuyIn = tournament.MaxBuyIn;
            tour.MinBuyIN = tournament.MinBuyIN;

            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Tournament()
        {
            return View("CreateTournament");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTournament(Tournament tournament)
        {
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Select(x => x.Value.Errors)
                //           .Where(y => y.Count > 0)
                //           .ToList();

                return View("CreateTournament", tournament); //need validation            
            }


            if (tournament.TournamentId == 0)
                context.Tournaments.Add(tournament);


            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}