using System;

namespace _01.CookingMasterclass
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceFlour = double.Parse(Console.ReadLine());
            double priceEgg = double.Parse(Console.ReadLine());
            double priceApron = double.Parse(Console.ReadLine());

            double expenses = (students * priceFlour) + (students * priceEgg * 10) + ((students + Math.Ceiling(students * 0.2)) * priceApron);
            expenses -= priceFlour * (students / 5);

            if (expenses <= budget)
            {
                Console.WriteLine($"Items purchased for {expenses:f2}$.");
            }
            else
            {
                Console.WriteLine($"{expenses-budget:f2}$ more needed.");
            }
        }
    }
}