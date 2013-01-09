using System;
using System.Web.Mvc;
using PracticalHTML5.Models;
using PracticalHTML5.ViewModels;

namespace PracticalHTML5.Controllers
{
    public class KOGameController : RavenController
    {
        public ActionResult Play(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Game(int id)
        {
            Response.Cache.SetMaxAge(TimeSpan.Zero);
            var game = DB.Load<TicTacToe>(id);
            return Json(game, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Game(int id, PlayResultViewModel viewModel)
        {
            var game = DB.Load<TicTacToe>(id);
            try
            {
                game.MakeMove(viewModel.MoveX, viewModel.MoveY, viewModel.Move);
                return Json(game, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
