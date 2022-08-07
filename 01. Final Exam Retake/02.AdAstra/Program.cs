using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(#|\|)(?<product>[A-Za-z ]+)\1(?<date>\d{2}/\d{2}/\d{2})\1(?<calories>\d+)\1");
            List<Item> items = new List<Item>();

            while (regex.IsMatch(input))
            {
                string name = regex.Match(input).Groups["product"].Value;
                string expiration = regex.Match(input).Groups["date"].Value;
                int calories = int.Parse(regex.Match(input).Groups["calories"].Value);
                Item item = new Item(name, expiration, calories);

                if (!items.Contains(item))
                {
                    items.Add(item);
                }

                input = input.Remove(0, regex.Match(input).Length + regex.Match(input).Index);
            }

            int days = items.Select(x => x.Calories).Sum() / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Item item in items)
            {
                Console.WriteLine($"Item: {item.Name}, Best before: {item.Expiration}, Nutrition: {item.Calories}");
            }
        }
    }

    class Item
    {
        public Item(string name, string expiration, int calories)
        {
            Name = name;
            Expiration = expiration;
            Calories = calories;
        }

        public string Name { get; set; }
        public string Expiration { get; set; }
        public int Calories { get; set; }
    }
}
