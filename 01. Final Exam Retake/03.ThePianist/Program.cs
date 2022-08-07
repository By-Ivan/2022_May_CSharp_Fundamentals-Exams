using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> pieces = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string name = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];

                if (!pieces.ContainsKey(name))
                {
                    pieces.Add(name, new string(composer + "-" + key));
                }
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] cmd = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

                switch (cmd[0])
                {
                    case "Add":
                        if (!pieces.ContainsKey(cmd[1]))
                        {
                            pieces.Add(cmd[1], new string(cmd[2] + "-" + cmd[3]));
                            Console.WriteLine($"{cmd[1]} by {cmd[2]} in {cmd[3]} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{cmd[1]} is already in the collection!");
                        }
                        break;
                    case "Remove":
                        if (pieces.ContainsKey(cmd[1]))
                        {
                            pieces.Remove(cmd[1]);
                            Console.WriteLine($"Successfully removed {cmd[1]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {cmd[1]} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        if (pieces.ContainsKey(cmd[1]))
                        {
                            string composer = pieces[cmd[1]].Split('-').ElementAt(0);
                            string newKey = cmd[2];
                            pieces[cmd[1]] = composer + "-" + newKey;
                            Console.WriteLine($"Changed the key of {cmd[1]} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {cmd[1]} does not exist in the collection.");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string,string> keyValuePair in pieces)
            {
                Console.WriteLine($"{keyValuePair.Key} -> Composer: {keyValuePair.Value.Split('-').ElementAt(0)}, Key: {keyValuePair.Value.Split('-').ElementAt(1)}");
            }
        }
    }
}