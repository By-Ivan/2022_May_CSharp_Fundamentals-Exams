using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex validStops = new Regex(@"(?<=(=|/))[A-Z][A-Za-z]{2,}(?=(\1))");

            List<string> stops = validStops.Matches(input).Select(x => x.Value).Distinct().ToList();
            int travelPoints = 0;

            stops.ForEach(x => travelPoints += x.ToCharArray().Length);

            Console.WriteLine($"Destinations: {string.Join(", ", stops)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}