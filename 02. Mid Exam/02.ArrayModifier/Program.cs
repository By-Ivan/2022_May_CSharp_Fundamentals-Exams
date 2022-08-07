using System;
using System.Linq;

namespace _02.ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                int index1 = command.Length > 1 ? int.Parse(command[1]) : 0;
                int index2 = command.Length > 1 ? int.Parse(command[2]) : 0;

                switch (command[0])
                {
                    case "swap":
                        if (Math.Min(index1, index2) >= 0 && Math.Max(index1, index2) < integers.Length)
                        {
                            int tmpInt = integers[index1];
                            integers[index1] = integers[index2];
                            integers[index2] = tmpInt;
                        }
                        break;

                    case "multiply":
                        if (Math.Min(index1, index2) >= 0 && Math.Max(index1, index2) < integers.Length)
                        {
                            integers[index1] *= integers[index2];
                        }
                        break;

                    case "decrease":
                        for (int i = 0; i < integers.Length; i++)
                        {
                            integers[i]--;
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", integers));
        }
    }
}
