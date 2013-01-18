using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using PracticalHTML5.Models;
using PracticalHTML5.ViewModels;
using Raven.Client;

namespace PracticalHTML5.Hubs
{
    [HubName("ticTacToe")]
    public class TicTacToeHub : Hub
    {
        public TicTacToe LoadGame(int id)
        {
            var game = DB.Load<TicTacToe>(id);
            return game;
        }

        public TicTacToe MakeMove(int id, PlayResultViewModel viewModel)
        {
            var game = DB.Load<TicTacToe>(id);
            game.MakeMove(viewModel.MoveX, viewModel.MoveY, viewModel.Move);
            DB.SaveChanges();

            Clients.Others.moveMade(game);
            return game;
        }



        private IDocumentSession _db;
        private IDocumentSession DB
        {
            get
            {
                _db = _db ?? Global.DocumentStore.OpenSession();
                return _db;
            }
            set { _db = value; }
        }


    }
}