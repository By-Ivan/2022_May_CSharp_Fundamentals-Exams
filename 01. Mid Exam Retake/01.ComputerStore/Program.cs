using System;

namespace _01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;

            while (input != "special" && input != "regular")
            {
                double price = double.Parse(input);
                if (price <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    sum += price;
                }
                input = Console.ReadLine();
            }
            if (sum == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                double totalPrice = input == "special" ? (sum + sum * 0.2) * 0.9 : sum + sum * 0.2;
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sum:f2}$");
                Console.WriteLine($"Taxes: {sum * 0.2:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:f2}$");
            }
        }
    }
}
