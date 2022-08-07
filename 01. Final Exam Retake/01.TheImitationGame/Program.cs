using System;
using System.Text;

namespace _01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] cmd = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

                switch (cmd[0])
                {
                    case "Move":
                        int n = int.Parse(cmd[1]);
                        encryptedMessage = Move(encryptedMessage, n);
                        break;
                    case "Insert":
                        int index = int.Parse(cmd[1]);
                        string value = cmd[2];
                        encryptedMessage = encryptedMessage.Insert(index, value);
                        break;
                    case "ChangeAll":
                        string substring = cmd[1];
                        string replacement = cmd[2];
                        encryptedMessage = encryptedMessage.Replace(substring, replacement);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }

        private static string Move(string encryptedMessage, int n)
        {
            StringBuilder result = new StringBuilder();

            for (int i = n; i < encryptedMessage.Length; i++)
            {
                result.Append(encryptedMessage[i]);
            }
            for (int i = 0; i < n; i++)
            {
                result.Append(encryptedMessage[i]);
            }

            return result.ToString();
        }
    }
}
