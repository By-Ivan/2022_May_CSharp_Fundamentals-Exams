using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _03.NeedforSpeedIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Garage garage = new Garage();

            FillGarage(garage, n);

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] cmd = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                switch (cmd[0])
                {
                    case "Drive":
                        garage.Drive(cmd[1], int.Parse(cmd[2]), int.Parse(cmd[3]));
                        break;

                    case "Refuel":
                        garage.Refuel(cmd[1], int.Parse(cmd[2]));
                        break;

                    case "Revert":
                        garage.Revert(cmd[1], int.Parse(cmd[2]));
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(garage);
        }

        private static void FillGarage(Garage garage, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split('|');

                if (!garage.Cars.Select(x => x.Model).Contains(carInfo[0]))
                {
                    garage.Cars.Add(new Car(carInfo[0], int.Parse(carInfo[1]), int.Parse(carInfo[2])));
                }
            }
        }
    }

    class Car
    {
        public Car(string model, int mileage, int fuel)
        {
            Model = model;
            Mileage = mileage;
            Fuel = fuel;
        }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }

    class Garage
    {
        public Garage()
        {
            Cars = new List<Car>();
        }
        public List<Car> Cars { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            this.Cars.ForEach(x => result.AppendLine($"{x.Model} -> Mileage: {x.Mileage} kms, Fuel in the tank: {x.Fuel} lt."));
            return result.ToString();
        }
        public void Drive(string model, int distance, int fuel)
        {
            int index = this.Cars.FindIndex(x => x.Model == model);

            if (this.Cars[index].Fuel < fuel)
            {
                Console.WriteLine($"Not enough fuel to make that ride");
            }
            else
            {
                this.Cars[index].Fuel -= fuel;
                this.Cars[index].Mileage += distance;
                Console.WriteLine($"{this.Cars[index].Model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                if (this.Cars[index].Mileage >= 100000)
                {
                    Console.WriteLine($"Time to sell the {this.Cars[index].Model}!");
                    this.Cars.Remove(Cars[index]);
                }
            }
        }
        public void Refuel(string model, int fuel)
        {
            int index = this.Cars.FindIndex(x => x.Model == model);

            if (this.Cars[index].Fuel + fuel > 75)
            {
                Console.WriteLine($"{this.Cars[index].Model} refueled with {75 - this.Cars[index].Fuel} liters");
                this.Cars[index].Fuel = 75;
            }
            else
            {
                this.Cars[index].Fuel += fuel;
                Console.WriteLine($"{this.Cars[index].Model} refueled with {fuel} liters");
            }
        }
        public void Revert(string model, int kilometers)
        {
            int index = this.Cars.FindIndex(x => x.Model == model);

            if (this.Cars[index].Mileage - kilometers < 10000)
            {
                kilometers = this.Cars[index].Mileage - 10000;
                this.Cars[index].Mileage = 10000;
            }
            else
            {
                this.Cars[index].Mileage -= kilometers;
                Console.WriteLine($"{this.Cars[index].Model} mileage decreased by {kilometers} kilometers");
            }
        }
    }
}
