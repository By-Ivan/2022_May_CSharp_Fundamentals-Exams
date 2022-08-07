using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] target = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            int shots = 0;

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index >= 0 && index < target.Length && target[index] != -1)
                {
                    for (int i = 0; i < target.Length; i++)
                    {
                        if (target[i] == -1 || i == index)
                        {
                            continue;
                        }
                        else if (target[i] > target[index])
                        {
                            target[i] -= target[index];
                        }
                        else if (target[i] <= target[index])
                        {
                            target[i] += target[index];
                        }
                    }

                    target[index] = -1;
                    shots++;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {shots} -> " + string.Join(' ', target));
        }
    }
}
