using System;

namespace XO
{
    public abstract class TicTacToeBase
    {
        protected char[] board;
        protected int currentPlayer;

        public TicTacToeBase()
        {
            board = new char[10]; // Ignore index 0
            for (int i = 1; i < 10; i++)
                board[i] = (char)(i + '0'); // Initialize with numbers 1 to 9
            currentPlayer = 1;
        }

        public abstract void PlayAI(); // Abstract method for game loop

        public abstract void Play();
        // Other common methods (DisplayBoard, IsValidMove, CheckWin) can be implemented here

        
    }

}
