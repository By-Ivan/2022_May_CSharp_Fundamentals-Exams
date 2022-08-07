using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.EncryptingPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex passwordValidator = new Regex(@"^(.+)>(?<numbers>\d{3})\|(?<lowercase>[a-z]{3})\|(?<uppercase>[A-Z]{3})\|(?<symbols>[^<>]{3})<(\1)$");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (passwordValidator.IsMatch(input))
                {
                    Match match = passwordValidator.Match(input);
                    StringBuilder encryptedPassword = new StringBuilder();
                    encryptedPassword.Append(match.Groups["numbers"].Value);
                    encryptedPassword.Append(match.Groups["lowercase"].Value);
                    encryptedPassword.Append(match.Groups["uppercase"].Value);
                    encryptedPassword.Append(match.Groups["symbols"].Value);
                    Console.WriteLine($"Password: {encryptedPassword.ToString()}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
