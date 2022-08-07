using System;

namespace _01.GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {   // quantity of food in kilograms for 30 days
            double food = double.Parse(Console.ReadLine());
            double hay = double.Parse(Console.ReadLine());
            double cover = double.Parse(Console.ReadLine());
            //guinea pig's weight in kilograms
            double guineadWeight = double.Parse(Console.ReadLine());
            bool isEnough = true;
            int day = 1;

            while (isEnough && day <= 30)
            {
                food -= 0.3f;
                hay = day % 2 == 0 ? hay -= food * 0.05 : hay;
                cover = day % 3 == 0 ? cover -= guineadWeight / 3 : cover;
                isEnough = food <= 0 || hay <= 0 || cover <= 0 ? false : true;
                day++;
            }

            if (isEnough)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}
