using System;

namespace XO
{
    // AI opponent using Minimax algorithm
    public class MinimaxAI : IPlayer
    {
        public int GetMove(char[] board)
        {
            
            Random random = new Random();
            int move;
            do
            {
                move = random.Next(1, 10);
            } while (board[move] != move.ToString()[0]);
            return move;
        }
    }

}
