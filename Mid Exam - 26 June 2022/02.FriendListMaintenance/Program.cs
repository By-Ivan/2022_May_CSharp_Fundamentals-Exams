using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.FriendListMaintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();
            int numBlacklisted = 0;
            int numLost = 0;

            while (input != "Report")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "Blacklist":
                        int nameIndex = friendsList.IndexOf(command[1]);
                        if (nameIndex != -1)
                        {
                            friendsList.RemoveAt(nameIndex);
                            friendsList.Insert(nameIndex, "Blacklisted");
                            Console.WriteLine($"{command[1]} was blacklisted.");
                            numBlacklisted++;
                        }
                        else
                        {
                            Console.WriteLine($"{command[1]} was not found.");
                        }
                        break;

                    case "Error":
                        int index = int.Parse(command[1]);
                        
                        if (index >= 0 && index < friendsList.Count && friendsList[index] != "Blacklisted" && friendsList[index] != "Lost")
                        {
                            string name = friendsList[index];
                            friendsList.RemoveAt(index);
                            friendsList.Insert(index, "Lost");
                            Console.WriteLine($"{name} was lost due to an error.");
                            numLost++;
                        }
                        break;

                    case "Change":
                        int oldNameIndex = int.Parse(command[1]);

                        if (oldNameIndex >= 0 && oldNameIndex < friendsList.Count)
                        {
                            string oldName = friendsList[oldNameIndex];
                            string newName = command[2];
                            friendsList.RemoveAt(oldNameIndex);
                            friendsList.Insert(oldNameIndex, newName);
                            Console.WriteLine($"{oldName} changed his username to {newName}.");
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Blacklisted names: {numBlacklisted}");
            Console.WriteLine($"Lost names: {numLost}");
            Console.WriteLine(String.Join(' ', friendsList));
        }
    }
}