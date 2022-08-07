using System;
using System.Linq;

namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] cmd = input.Split(">>>");

                switch (cmd[0])
                {
                    case "Contains":
                        if (key.Contains(cmd[1]))
                        {
                            Console.WriteLine($"{key} contains {cmd[1]}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;

                    case "Flip":
                        int startIndex = int.Parse(cmd[2]);
                        int endIndex = int.Parse(cmd[3]);
                        string substring = key.Substring(startIndex, endIndex - startIndex);

                        if (cmd[1] == "Upper")
                        {
                            key = key.Replace(substring, substring.ToUpper());
                        }
                        else if (cmd[1] == "Lower")
                        {
                            key = key.Replace(substring, substring.ToLower());
                        }
                        Console.WriteLine(key);
                        break;

                    case "Slice":
                        startIndex = int.Parse(cmd[1]);
                        endIndex = int.Parse(cmd[2]);
                        key = key.Remove(startIndex, endIndex - startIndex);
                        Console.WriteLine(key);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}