using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> result = new List<int>();
            double avgArr = Math.Round(arr.Sum() / (double)arr.Length, 2);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > avgArr)
                {
                    result.Add(arr[i]);
                }
            }
            if (result.Count < 1)
            {
                Console.WriteLine("No");
            }
            else
            {
                result.Sort();
                int start = result.Count > 5 ? result.Count - 5 : 0;
                for (int i = result.Count - 1; i >= start; i--)
                {
                    Console.Write($"{result[i]} ");
                }
            }
        }
    }
}
