using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string item = command[1];

                switch (command[0])
                {
                    case "Urgent":
                        if (!shoppingList.Contains(item))
                        {
                            shoppingList.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        if (shoppingList.Contains(item))
                        {
                            shoppingList.Remove(item);
                        }
                        break;
                    case "Correct":
                        if (shoppingList.Contains(item))
                        {
                            int index = shoppingList.IndexOf(item);
                            string newItem = command[2];
                            shoppingList[index] = newItem;
                        }
                        break;
                    case "Rearrange":
                        if (shoppingList.Contains(item))
                        {
                            shoppingList.Add(item);
                            shoppingList.RemoveAt(shoppingList.IndexOf(item));
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", shoppingList));
        }
    }
}
