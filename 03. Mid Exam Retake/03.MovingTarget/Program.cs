using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int index = int.Parse(command[1]);

                switch (command[0])
                {
                    case "Shoot":
                        int power = int.Parse(command[2]);
                        Shoot(targets, index, power);
                        break;
                    case "Add":
                        int value = int.Parse(command[2]);
                        Add(targets, index, value);
                        break;
                    case "Strike":
                        int radius = int.Parse(command[2]);
                        Strike(targets, index, radius);
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join('|', targets));
        }

        static void Shoot(List<int> targets, int index, int power)
        {
            if (index >= 0 && index < targets.Count)
            {
                if (power >= targets[index])
                {
                    targets.RemoveAt(index);
                }
                else
                {
                    targets[index] -= power;
                }
            }
        }

        static void Add(List<int> targets, int index, int value)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        static void Strike(List<int> targets, int index, int radius)
        {
            int lowerLimit = index - radius;
            int upperLimit = index + radius;

            if (index < 0 || index >= targets.Count || lowerLimit < 0 || upperLimit >= targets.Count)
            {
                Console.WriteLine("Strike missed!");
            }
            else
            {
                targets.RemoveRange(lowerLimit, radius * 2 + 1);
            }
        }
    }
}
