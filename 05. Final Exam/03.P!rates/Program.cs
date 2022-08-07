using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = TargetCities();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] cmd = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                int index = cities.IndexOf(cities.FirstOrDefault(x => x.Name == cmd[1]));

                switch (cmd[0])
                {
                    case "Plunder":
                        cities[index].Plunder(int.Parse(cmd[2]), int.Parse(cmd[3]));
                        break;

                    case "Prosper":
                        cities[index].Prosper(int.Parse(cmd[2]));
                        break;
                }

                if (cities[index].Gold <= 0 || cities[index].Population <= 0)
                {
                    cities.RemoveAt(index);
                    Console.WriteLine($"{cmd[1]} has been wiped off the map!");
                }

                input = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                cities.ForEach(x => Console.WriteLine($"{x.Name} -> Population: {x.Population} citizens, Gold: {x.Gold} kg"));
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        static List<City> TargetCities()
        {
            List<City> cities = new List<City>();

            string input = Console.ReadLine();

            while (input != "Sail")
            {
                string[] cityInfo = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string city = cityInfo[0];
                int population = int.Parse(cityInfo[1]);
                int gold = int.Parse(cityInfo[2]);

                if (!cities.Select(x => x.Name).Contains(cityInfo[0]))
                {
                    cities.Add(new City(city, population, gold));
                }
                else
                {
                    int index = cities.IndexOf(cities.FirstOrDefault(x => x.Name == city));
                    cities[index].Population += population;
                    cities[index].Gold += gold;
                }

                input = Console.ReadLine();
            }

            return cities;
        }
    }

    class City
    {
        public City(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public void Plunder(int people, int gold)
        {
            this.Population -= people;
            this.Gold -= gold;

            Console.WriteLine($"{this.Name} plundered! {gold} gold stolen, {people} citizens killed.");
        }

        public void Prosper(int gold)
        {
            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else
            {
                this.Gold += gold;
                Console.WriteLine($"{gold} gold added to the city treasury. {this.Name} now has {this.Gold} gold.");
            }
        }
    }
}