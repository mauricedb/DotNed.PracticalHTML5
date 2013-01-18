using System;
using System.Web.Mvc;
using PracticalHTML5.Models;
using PracticalHTML5.ViewModels;

namespace PracticalHTML5.Controllers
{
    public class SimpleGameController : RavenController
    {

        public ActionResult Play(int id)
        {
            var game = DB.Load<TicTacToe>(id);

            return View(new PlayRequestViewModel
            {
                Game = game,
                IsTurn = game.IsTurn(UserName)
            });
        }

        [HttpPost]
        public ActionResult Play(int id, PlayResultViewModel viewModel)
        {
            var game = DB.Load<TicTacToe>(id);
            try
            {
                game.MakeMove(viewModel.MoveX, viewModel.MoveY, viewModel.Move);
                return RedirectToAction("Play");

            }
            catch (Exception ex)
            {
                return View(new PlayRequestViewModel
                {
                    Game = game,
                    IsTurn = game.IsTurn(UserName),
                    ErrorMessage = ex.Message
                });
            }
        }


    }
}
