using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] cmd = input.Split(' ');

                switch (cmd[0])
                {
                    case "TakeOdd":
                        StringBuilder result = new StringBuilder();
                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                result.Append(password[i]);
                            }
                        }
                        password = result.ToString();
                        Console.WriteLine(password);
                        break;

                    case "Cut":
                        int index = int.Parse(cmd[1]);
                        int length = int.Parse(cmd[2]);

                        password = password.Remove(index, length);
                        Console.WriteLine(password);
                        break;

                    case "Substitute":
                        string substring = cmd[1];
                        string replacement = cmd[2];

                        if (password.Contains(substring))
                        {
                            password = password.Replace(substring, replacement);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}