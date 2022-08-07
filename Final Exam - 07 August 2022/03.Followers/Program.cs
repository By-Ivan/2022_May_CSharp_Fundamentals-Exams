using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Followers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> followers = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "Log out")
            {
                string[] cmd = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                switch (cmd[0])
                {
                    case "New follower":
                        if (!followers.ContainsKey(cmd[1]))
                        {
                            followers.Add(cmd[1], 0);
                        }
                        break;

                    case "Like":
                        if (!followers.ContainsKey(cmd[1]))
                        {
                            followers.Add(cmd[1], int.Parse(cmd[2]));
                        }
                        else
                        {
                            followers[cmd[1]] += int.Parse(cmd[2]);
                        }
                        break;

                    case "Comment":
                        if (!followers.ContainsKey(cmd[1]))
                        {
                            followers.Add(cmd[1], 1);
                        }
                        else
                        {
                            followers[cmd[1]]++;
                        }
                        break;

                    case "Blocked":
                        if (followers.ContainsKey(cmd[1]))
                        {
                            followers.Remove(cmd[1]);
                        }
                        else
                        {
                            Console.WriteLine($"{cmd[1]} doesn't exist.");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{followers.Count} followers");
            foreach (KeyValuePair<string,int> follower in followers)
            {
                Console.WriteLine($"{follower.Key}: {follower.Value}");
            }
        }
    }
}
