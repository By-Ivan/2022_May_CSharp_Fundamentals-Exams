using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex barcodePattern = new Regex(@"@#{1,}[A-Z][A-Za-z0-9]{4,}[A-Z]@#{1,}");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string password = Console.ReadLine();

                if (barcodePattern.IsMatch(password))
                {
                    string productGroup = "00";
                    if (password.ToCharArray().Select(x => x).Where(x => char.IsDigit(x)).ToArray().Length > 0)
                    {
                        productGroup = String.Join("", password.ToCharArray().Select(x => x).Where(x => char.IsDigit(x)).ToArray());
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}