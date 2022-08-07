using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stops = new StringBuilder();
            stops.Append(new string(Console.ReadLine().ToCharArray()));
            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] cmd = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

                switch (cmd[0])
                {
                    case "Add Stop":
                        int index = int.Parse(cmd[1]);
                        string stop = cmd[2];

                        if (index >= 0 && index < stops.Length)
                        {
                            stops.Insert(index,stop);
                        }

                        Console.WriteLine(stops.ToString());
                        break;

                    case "Remove Stop":
                        int startIndex = int.Parse(cmd[1]);
                        int endIndex = int.Parse(cmd[2]);

                        if (startIndex >= 0 && startIndex <= endIndex && endIndex < stops.Length)
                        {
                            stops.Remove(startIndex,endIndex-startIndex+1);
                        }

                        Console.WriteLine(stops.ToString());
                        break;

                    case "Switch":
                        string oldString = cmd[1];
                        string newString = cmd[2];

                        if (stops.ToString().Contains(oldString))
                        {
                            stops.Replace(oldString,newString);
                        }

                        Console.WriteLine(stops.ToString());
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}