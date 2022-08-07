using System;
using System.Linq;

namespace _02.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int queue = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int liftLimit = 4;

            for (int i = 0; i < lift.Length; i++)
            {
                int freeSpots = liftLimit - lift[i];

                if (freeSpots > 0)
                {
                    lift[i] = queue - freeSpots >= 0 ? lift[i] += freeSpots : lift[i] += queue;
                    queue = queue - freeSpots >= 0 ? queue -= freeSpots : 0;
                }
            }
            if (queue > 0)
            {
                Console.WriteLine($"There isn't enough space! {queue} people in a queue!");
            }
            else if (lift.Sum() < lift.Length * liftLimit)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            Console.WriteLine(string.Join(' ', lift));
        }
    }
}
