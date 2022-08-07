using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] cmd = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string substring = cmd[1];

                switch (cmd[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(cmd[1]);
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;

                    case "Reverse":
                        if (message.Contains(substring))
                        {
                            message = message.Remove(message.IndexOf(substring), substring.Length) + String.Join("", substring.Reverse().ToList());
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                    case "ChangeAll":
                        string replacement = cmd[2];
                        message = message.Replace(substring, replacement);
                        Console.WriteLine(message);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
