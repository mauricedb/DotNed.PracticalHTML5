using System.Linq;
using PracticalHTML5.Models;
using PracticalHTML5.ViewModels;
using Raven.Client.Indexes;

namespace PracticalHTML5.Indexes
{
    public class PlayerStatisticsIndexCreationTask : AbstractMultiMapIndexCreationTask<PlayerStatisticsIndexCreationTask.Result>
    {
        public class Result
        {
            public string Player { get; set; }
            public int Win { get; set; }
            public int Lose { get; set; }
            public int Draw { get; set; }
        }

        public PlayerStatisticsIndexCreationTask()
        {
            AddMap<TicTacToe>(docs => from g in docs
                                      select new Result
                                                 {
                                                     Player = g.PlayerX,
                                                     Win = g.Winner == "X" ? 1 : 0,
                                                     Lose = g.Winner == "O" ? 1 : 0,
                                                     Draw = g.Winner == "Draw" ? 1 : 0
                                                 });

            AddMap<TicTacToe>(docs => from g in docs
                                      select new Result
                                                 {
                                                     Player = g.PlayerO,
                                                     Win = g.Winner == "O" ? 1 : 0,
                                                     Lose = g.Winner == "X" ? 1 : 0,
                                                     Draw = g.Winner == "Draw" ? 1 : 0
                                                 });


            Reduce = results => from p in results
                                group p by p.Player
                                into r
                                select new Result
                                           {
                                               Player = r.Key,
                                               Win = r.Sum(g => g.Win),
                                               Lose = r.Sum(g => g.Lose),
                                               Draw = r.Sum(g => g.Draw),
                                           };
        }
    }
}