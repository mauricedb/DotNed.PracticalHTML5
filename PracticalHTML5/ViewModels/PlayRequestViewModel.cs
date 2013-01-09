using PracticalHTML5.Models;

namespace PracticalHTML5.ViewModels
{
    public class PlayRequestViewModel
    {
        public TicTacToe Game { get; set; }
        public bool IsTurn { get; set; }
        public string ErrorMessage { get; set; }
    }
}