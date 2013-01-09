using System.Collections.Generic;
using PracticalHTML5.Models;

namespace PracticalHTML5.ViewModels
{
    public class HomeIndexRequestViewModel
    {
        public List<TicTacToe> New { get; set; }
        public List<TicTacToe> Active { get; set; }
        public List<TicTacToe> Finished { get; set; }
        public string UserName { get; set; }
    }
}