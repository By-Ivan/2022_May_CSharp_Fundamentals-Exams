using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex emoji = new Regex(@"(:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})(\1)");
            Regex digits = new Regex(@"\d");
            List<string> coolEmojis = new List<string>();
            long treshold = digits.Matches(input).Select(x => int.Parse(x.Value)).Aggregate((x1, x2) => x1 * x2);

            foreach (Match match in emoji.Matches(input))
            {
                long coolness = match.Groups["emoji"].Value.Select(x=>(int)x).Aggregate((x1,x2) => x1 + x2);

                if (coolness >= treshold)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {treshold}");
            Console.WriteLine($"{emoji.Matches(input).Count} emojis found in the text. The cool ones are:");
            coolEmojis.ForEach(x => Console.WriteLine(x));
        }
    }
}