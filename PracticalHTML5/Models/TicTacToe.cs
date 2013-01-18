using System;

namespace PracticalHTML5.Models
{
    public class TicTacToe
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; }
        public string PlayerX { get; set; }
        public string PlayerO { get; set; }
        public string Winner { get; set; }
        public bool Draw { get; set; }
        public string Move { get; set; }
        public string[][] Cells { get; set; }

        public string CurrentUserName
        {
            get
            {
                if (string.IsNullOrEmpty(Move))
                {
                    return string.Empty;
                }

                return Move == "X" ? PlayerX : PlayerO;
            }
        }

        public void Initialize(int size)
        {
            Move = "X";
            Cells = new string[size][];
            Cells = new string[size][];
            for (int i = 0; i < Cells.Length; i++)
            {
                Cells[i] = new string[size];
            }
        }

        public void MakeMove(int moveX, int moveY, string move)
        {
            ValidateMove(moveX, moveY);

            Cells[moveX][moveY] = move;
            Move = Move == "O" ? "X" : "O";
            CheckForWinner();
        }

        private void ValidateMove(int moveX, int moveY)
        {
            if (moveX >= Cells.Length || moveX < 0)
            {
                throw new InvalidOperationException("Invalid row number.");
            }

            if (moveY >= Cells.Length || moveY < 0)
            {
                throw new InvalidOperationException("Invalid column number.");
            }

            if (!string.IsNullOrEmpty(Cells[moveX][moveY]))
            {
                throw new InvalidOperationException("Can't play an already taken cell.");
            }

            if (!string.IsNullOrEmpty(Winner))
            {
                throw new InvalidOperationException("Can't play an already finished game.");
            }
        }

        public void CheckForWinner()
        {
            if (CheckRows()) return;

            if (CheckColumns()) return;
            if (CheckDiagonals()) return;

            CheckForDraw();
        }

        private void CheckForDraw()
        {
            for (int i = 0; i < Cells.Length; i++)
            {
                for (int j = 0; j < Cells.Length; j++)
                {
                    if (string.IsNullOrEmpty(Cells[i][j]))
                    {
                        return;
                    }
                }
            }
            Winner = "Draw";
            Draw = true;
            Move = string.Empty;
        }

        private bool CheckDiagonals()
        {
            var isWinner = !string.IsNullOrEmpty(Cells[0][0]);
            for (int i = 1; i < Cells.Length; i++)
            {
                isWinner = isWinner && Cells[i - 1][i - 1] == Cells[i][i];
            }
            if (isWinner)
            {
                Winner = Cells[0][0];
                Move = string.Empty;
                return true;
            }

            isWinner = !string.IsNullOrEmpty(Cells[0][Cells.Length - 1]);
            for (int i = 1; i < Cells.Length; i++)
            {
                isWinner = isWinner && Cells[i - 1][Cells.Length - i] == Cells[i][Cells.Length - i - 1];
            }
            if (isWinner)
            {
                Winner = Cells[0][Cells.Length - 1];
                Move = string.Empty;
                return true;
            }
            return false;
        }

        private bool CheckColumns()
        {
            for (int i = 0; i < Cells.Length; i++)
            {
                var isWinner = !string.IsNullOrEmpty(Cells[0][i]);

                for (int j = 1; j < Cells.Length; j++)
                {
                    isWinner = isWinner && Cells[j - 1][i] == Cells[j][i];
                }

                if (isWinner)
                {
                    Winner = Cells[0][i];
                    Move = string.Empty;
                    return true;
                }
            }
            return false;
        }

        private bool CheckRows()
        {
            for (int i = 0; i < Cells.Length; i++)
            {
                var isWinner = !string.IsNullOrEmpty(Cells[i][0]);

                for (int j = 1; j < Cells.Length; j++)
                {
                    isWinner = isWinner && Cells[i][j - 1] == Cells[i][j];
                }

                if (isWinner)
                {
                    Winner = Cells[i][0];
                    Move = string.Empty;
                    return true;
                }
            }
            return false;
        }

        public bool IsTurn(string userName)
        {
            var activeUser = Move == "X" ? PlayerX : PlayerO;
            return activeUser == userName && string.IsNullOrEmpty(Winner);
        }
    }
}