using System;

namespace _01.Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int victories = 0;
            bool outOfEnergy = false;

            while (input != "End of battle")
            {
                int distance = int.Parse(input);

                if (distance > energy)
                {
                    outOfEnergy = true;
                    break;
                }

                energy -= distance;
                victories++;
                energy = victories % 3 == 0 ? energy += victories : energy;

                input = Console.ReadLine();
            }

            if (outOfEnergy)
            {
                Console.WriteLine($"Not enough energy! Game ends with {victories} won battles and {energy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {victories}. Energy left: {energy}");
            }
        }
    }
}
