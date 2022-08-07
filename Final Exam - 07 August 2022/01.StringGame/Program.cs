using System;

namespace _01.StringGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] cmd = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                switch (cmd[0])
                {
                    case "Change":
                        word = word.Replace(cmd[1], cmd[2]);
                        Console.WriteLine(word);
                        break;

                    case "Includes":
                        if (word.Contains(cmd[1]))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;

                    case "End":
                        if (word.EndsWith(cmd[1]))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;

                    case "Uppercase":
                        word = word.ToUpper();
                        Console.WriteLine(word);
                        break;

                    case "FindIndex":
                        Console.WriteLine($"{word.IndexOf(cmd[1])}");
                        break;

                    case "Cut":
                        word = word.Substring(int.Parse(cmd[1]), int.Parse(cmd[2]));
                        Console.WriteLine(word);
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
