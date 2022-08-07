using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex hiddenWords = new Regex(@"(?<=(?<separator>@|#))(?<word1>[A-Za-z]{3,})\1{2}(?<word2>[A-Za-z]{3,})(?=\1)");
            List<string> mirroredPairs = new List<string>();
            int validPairs = 0;

            foreach (Match match in hiddenWords.Matches(input))
            {
                validPairs++;
                string word1 = match.Groups["word1"].Value;
                string word2 = match.Groups["word2"].Value;

                if (word1 == String.Join("", word2.Reverse().ToArray()))
                {
                    mirroredPairs.Add(word1 + " <=> " + word2);
                }
            }

            if (validPairs == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{validPairs} word pairs found!");

                if (mirroredPairs.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ", mirroredPairs));
                }
            }
        }
    }
}
