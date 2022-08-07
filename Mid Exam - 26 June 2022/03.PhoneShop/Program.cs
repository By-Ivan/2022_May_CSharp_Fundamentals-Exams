using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.PhoneShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "Add":
                        if (!phones.Contains(command[1]))
                        {
                            phones.Add(command[1]);
                        }
                        break;

                    case "Remove":
                        if (phones.Contains(command[1]))
                        {
                            phones.Remove(command[1]);
                        }
                        break;

                    case "Bonus phone":
                        string[] phone = command[1].Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                        if (phones.Contains(phone[0]))
                        {
                            int index = phones.IndexOf(phone[0]);
                            phones.Insert(index + 1, phone[1]);
                        }
                        break;

                    case "Last":
                        if (phones.Contains(command[1]))
                        {
                            int index = phones.IndexOf(command[1]);
                            phones.Add(command[1]);
                            phones.RemoveAt(index);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ", phones));
        }
    }
}