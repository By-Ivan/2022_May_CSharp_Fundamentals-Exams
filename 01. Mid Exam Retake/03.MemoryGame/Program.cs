using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();
            int moves = 0;
            bool isWinner = false;

            while (input != "end")
            {
                int[] index = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                moves++;

                if (index[0] == index[1] || index[0] < 0 || index[0] >= elements.Count || index[1] < 0 || index[1] >= elements.Count)
                {
                    string cheaterElement = $"-{moves}a";
                    elements.Insert(elements.Count / 2, cheaterElement);
                    elements.Insert(elements.Count / 2, cheaterElement);
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else if (elements[index[0]] == elements[index[1]])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[index[0]]}!");
                    elements.RemoveAt(index.Min());
                    elements.RemoveAt(index.Max() - 1);
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (elements.Count == 0)
                {
                    isWinner = true;
                    break;
                }

                input = Console.ReadLine();
            }

            if (isWinner)
            {
                Console.WriteLine($"You have won in {moves} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(String.Join(' ', elements));
            }
        }
    }
}
