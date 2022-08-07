using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();

            FillExibition(plants, n);

            Exhibition(plants);

            Console.WriteLine("Plants for the exhibition:");
            plants.ForEach(x => Console.WriteLine($"- {x.Name}; Rarity: {x.Rarity}; Rating: {(x.Rating.Count > 0 ? x.Rating.Average() : 0):f2}"));
        }

        private static void Exhibition(List<Plant> plants)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Exhibition")
                {
                    return;
                }

                string[] cmd = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string plant = cmd[1].Split(" - ").ElementAt(0).ToString();
                int index = plants.IndexOf(plants.FirstOrDefault(x => x.Name == plant));

                if (index == -1)
                {
                    Console.WriteLine("error");
                    continue;
                }
                else
                {
                    switch (cmd[0])
                    {
                        case "Rate":
                            double rating = double.Parse(cmd[1].Split(" - ").ElementAt(1).ToString());

                            plants[index].Rating.Add(rating);

                            break;

                        case "Update":
                            int rarity = int.Parse(cmd[1].Split(" - ").ElementAt(1).ToString());

                            plants[index].Rarity = rarity;

                            break;

                        case "Reset":

                            plants[index].Rating.Clear();

                            break;
                    }
                }
            }
        }

        private static void FillExibition(List<Plant> plants, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = cmd[0];
                int rarity = int.Parse(cmd[1]);

                if (!plants.Select(x => x.Name).Contains(plant))
                {
                    plants.Add(new Plant(plant, rarity));
                }
            }
        }
    }

    class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Rating = new List<double>();
        }

        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<double> Rating { get; set; }
    }
}