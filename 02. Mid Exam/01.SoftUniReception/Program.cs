using System;
using System.Linq;

namespace _01.SoftUniReception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] workerSpeed = new int[3];
            for (int i = 0; i < workerSpeed.Length; i++)
            {
                workerSpeed[i] = int.Parse(Console.ReadLine());
            }
            int students = int.Parse(Console.ReadLine());
            int hours = 0;

            while (students > 0)
            {
                students -= workerSpeed.Sum();
                hours = hours != 0 && (hours + 1) % 4 == 0 ? hours += 2 : hours += 1;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
