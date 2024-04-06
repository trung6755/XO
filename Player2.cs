using System;

namespace XO
{
    public class Player2 : IPlayer
    {
        public int GetMove(char[] board)
        {
            int choice;
            Console.Write("\nEnter your choice (1-9): ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }

}
