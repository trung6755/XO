using System;

namespace XO
{
    // Main game class
    public class TicTacToeGame : TicTacToeBase
    {
        private IPlayer player2; // Human opponent
        
        public TicTacToeGame(IPlayer player2)
        {
            this.player2 = player2;
        }

        public override void Play()
        {
            int flag = 0;

            do
            {
                Console.Clear();
                Console.WriteLine($"Player {currentPlayer}: {(currentPlayer == 1 ? 'X' : 'O')}\n");
                DisplayBoard();

                int choice;
                if (currentPlayer == 1)
                {
                    Console.Write("\nEnter your choice (1-9): ");
                    choice = int.Parse(Console.ReadLine());
                }
                else
                {
                    choice = player2.GetMove(board);
                }

                if (IsValidMove(choice))
                {
                    board[choice] = (currentPlayer == 1) ? 'X' : 'O';
                    currentPlayer = 3 - currentPlayer; // Switch players
                }
                else
                {
                    Console.WriteLine("Invalid move! Please choose an empty cell.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

                flag = CheckWin();
            } while (flag == 0);

            Console.Clear();
            DisplayBoard();

            if (flag == 1)
                Console.WriteLine($"Player {(3 - currentPlayer)} wins!");
            else
                Console.WriteLine("It's a draw!");
        }

        private void DisplayBoard()
        {
            Console.WriteLine($" {board[1]} | {board[2]} | {board[3]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[4]} | {board[5]} | {board[6]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[7]} | {board[8]} | {board[9]} ");
        }

        private bool IsValidMove(int choice)
        {
            return (choice >= 1 && choice <= 9 && board[choice] == (char)(choice + '0'));
        }

        private int CheckWin()
        {
            // Check rows, columns, and diagonals for a win
            if (board[1] == board[2] && board[2] == board[3] ||
                board[4] == board[5] && board[5] == board[6] ||
                board[7] == board[8] && board[8] == board[9] ||
                board[1] == board[4] && board[4] == board[7] ||
                board[2] == board[5] && board[5] == board[8] ||
                board[3] == board[6] && board[6] == board[9] ||
                board[1] == board[5] && board[5] == board[9] ||
                board[3] == board[5] && board[5] == board[7])
            {
                return 1; // Someone has won
            }
            else if (board[1] != '1' && board[2] != '2' && board[3] != '3' &&
                     board[4] != '4' && board[5] != '5' && board[6] != '6' &&
                     board[7] != '7' && board[8] != '8' && board[9] != '9')
            {
                return -1; // It's a draw
            }
            else
            {
                return 0; // Game still ongoing
            }
        }

        public override void PlayAI()
        {
            throw new NotImplementedException();
        }
    }

}
