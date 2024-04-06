using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XO
{

    // Interface for player interactions


    // Interface for player interactions
    public interface IPlayer
    {
        int GetMove(char[] board);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Choose game mode: ");
            Console.WriteLine("1. Vs Human");
            Console.WriteLine("2. Vs AI");
            Console.WriteLine("3. Quit");

            int choose = int.Parse(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    IPlayer player2 = new Player2();
                    TicTacToeBase game = new TicTacToeGame(player2);
                    game.Play();
                    break;
                case 2:
                    IPlayer aiOpponent = new MinimaxAI();
                    TicTacToeBase AIgame = new TicTacToeGame(aiOpponent);
                    AIgame.Play();
                    break;
                case 3:
                    Console.WriteLine("See you!");
                    break;

            }
            
        }
    }

}
