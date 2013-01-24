using System;
using System.Linq;
using System.Web.Mvc;
using PracticalHTML5.Models;
using PracticalHTML5.ViewModels;

namespace PracticalHTML5.Controllers
{
    public class HomeController : RavenController
    {
        //private const string _gameControler = "SimpleGame";
        //private const string _gameControler = "KOGame";
        private const string _gameControler = "SocketGame";


        public ActionResult Index()
        {
            var games = DB.Query<TicTacToe>().OrderByDescending(g => g.StartedAt);
            var model = new HomeIndexRequestViewModel
            {
                New = games.Where(g => string.IsNullOrEmpty(g.PlayerX)).ToList(),
                Active = games.Where(g => !string.IsNullOrEmpty(g.PlayerX) && string.IsNullOrEmpty(g.Winner)).ToList(),
                Finished = games.Where(g => !string.IsNullOrEmpty(g.Winner)).ToList(),
                UserName = UserName
            };
            return View(model);
        }


        public ActionResult Create()
        {
            var model = new HomeCreateRequestViewModel
            {
                StartedAt = DateTime.Now,
                PlayerO = UserName
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(HomeCreateRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newGame = new TicTacToe
                {
                    StartedAt = model.StartedAt ?? DateTime.Now,
                    PlayerO = model.PlayerO
                };
                newGame.Initialize(model.Size ?? 3);


                DB.Store(newGame);

                UserName = newGame.PlayerO;

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Accept(int id)
        {
            return View(new { PlayerX = UserName });
        }

        [HttpPost]
        public ActionResult Accept(int id, string playerX)
        {
            if (!string.IsNullOrEmpty(playerX))
            {
                var game = DB.Load<TicTacToe>(id);
                game.PlayerX = playerX;
                UserName = playerX;

                return RedirectToAction("Play", _gameControler, new { id });
            }

            ModelState.AddModelError("PlayerX", "Name is required.");
            return View();
        }


        public ActionResult Play(int id)
        {
            return RedirectToAction("Play", _gameControler, new { id });
        }
    }
}
