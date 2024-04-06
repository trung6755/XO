using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XO
{
    internal class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; // By default, player 1 starts
        static int choice; // Holds the position where the user wants to mark
        static int flag = 0; // Flag variable to check game status (win, draw, or ongoing)

        // Main function
        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); // Clear the screen when the loop starts again
                Console.WriteLine("Player 1: X and Player 2: O\n");

                // Display whose turn it is
                if (player % 2 == 0)
                    Console.WriteLine("Player 2's Turn");
                else
                    Console.WriteLine("Player 1's Turn");

                Console.WriteLine("\n");
                Board(); // Display the board

                // Take user's choice
                choice = int.Parse(Console.ReadLine());

                // Check if the chosen position is already marked
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    // Mark the position with X or O based on the player's turn
                    if (player % 2 == 0)
                        arr[choice] = 'O';
                    else
                        arr[choice] = 'X';

                    player++;
                }
                else
                {
                    // If the position is already marked, show a message and reload the board
                    Console.WriteLine($"Sorry, position {choice} is already marked with {arr[choice]}");
                    Console.WriteLine("\nPlease wait 2 seconds; the board is loading again...");
                    Thread.Sleep(2000);
                }

                flag = CheckWin(); // Check if someone has won or if it's a draw
            } while (flag != 1 && flag != -1);

            Console.Clear(); // Clear the console
            Board(); // Display the final filled board

            // Display the result
            if (flag == 1)
                Console.WriteLine("Player {0} wins!", (player % 2) + 1);
            else
                Console.WriteLine("It's a draw!");

            Console.ReadLine();
        }

        // Function to display the board
        private static void Board()
        {
            Console.WriteLine($" {arr[1]} | {arr[2]} | {arr[3]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {arr[4]} | {arr[5]} | {arr[6]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {arr[7]} | {arr[8]} | {arr[9]} ");
        }

        // Function to check if someone has won
        private static int CheckWin()
        {
            // Check rows, columns, and diagonals for a win
            if (arr[1] == arr[2] && arr[2] == arr[3] ||
                arr[4] == arr[5] && arr[5] == arr[6] ||
                arr[7] == arr[8] && arr[8] == arr[9] ||
                arr[1] == arr[4] && arr[4] == arr[7] ||
                arr[2] == arr[5] && arr[5] == arr[8] ||
                arr[3] == arr[6] && arr[6] == arr[9] ||
                arr[1] == arr[5] && arr[5] == arr[9] ||
                arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1; // Someone has won
            }
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' &&
                     arr[4] != '4' && arr[5] != '5' && arr[6] != '6' &&
                     arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1; // It's a draw
            }
            else
            {
                return 0; // Game still ongoing
            }
        }
    }
}
