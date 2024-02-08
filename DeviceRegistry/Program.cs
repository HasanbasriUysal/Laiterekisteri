using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRegistry
{
    public class Device
    {
        public string PurchaseDate { get; set; }
        public double PurchasePrice { get; set; }
        public int WarrantyMonths { get; set; }

        // Constructor
        public Device(string purchaseDate, double purchasePrice, int warrantyMonths)
        {
            PurchaseDate = purchaseDate;
            PurchasePrice = purchasePrice;
            WarrantyMonths = warrantyMonths;
        }

        // Method to calculate remaining warranty months
        public int RemainingWarrantyMonths()
        {
            DateTime purchaseDateTime = DateTime.Parse(PurchaseDate);
            DateTime now = DateTime.Now;
            DateTime warrantyEnd = purchaseDateTime.AddMonths(WarrantyMonths);
            int remainingMonths = (warrantyEnd - now).Days / 30;
            return Math.Max(0, remainingMonths); // Ensure non-negative value
        }

    }
    // Subclass for computers
    public class Computer : Device
    {
        public string Brand { get; set; }
        public string Processor { get; set; }

        public Computer(string purchaseDate, double purchasePrice, int warrantyMonths, string brand, string processor)
            : base(purchaseDate, purchasePrice, warrantyMonths)
        {
            Brand = brand;
            Processor = processor;
        }
    }

    // Subclass for phones
    public class Phone : Device
    {
        public string Brand { get; set; }
        public string OS { get; set; }

        public Phone(string purchaseDate, double purchasePrice, int warrantyMonths, string brand, string os)
            : base(purchaseDate, purchasePrice, warrantyMonths)
        {
            Brand = brand;
            OS = os;
        }
    }

    // Subclass for tablets
    public class Tablet : Device
    {
        public string Brand { get; set; }
        public string ScreenSize { get; set; }

        public Tablet(string purchaseDate, double purchasePrice, int warrantyMonths, string brand, string screenSize)
            : base(purchaseDate, purchasePrice, warrantyMonths)
        {
            Brand = brand;
            ScreenSize = screenSize;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer("2023-01-15", 1200.50, 24, "Dell", "Intel Core i7");

            // Output device information
            Console.WriteLine("Computer:");
            Console.WriteLine($"Brand: {computer.Brand}");
            Console.WriteLine($"Processor: {computer.Processor}");
            Console.WriteLine($"Purchase Date: {computer.PurchaseDate}");
            Console.WriteLine($"Purchase Price: {computer.PurchasePrice}");
            Console.WriteLine($"Warranty Months: {computer.WarrantyMonths}");
            Console.WriteLine($"Remaining Warranty Months: {computer.RemainingWarrantyMonths()}");
            Console.WriteLine("-----------------------------");


            Phone phone = new Phone("2023-05-20", 899.99, 12, "Apple", "iOS");
            // Output device information            
            Console.WriteLine("Phone:");
            Console.WriteLine($"Brand: {phone.Brand}");
            Console.WriteLine($"OS: {phone.OS}");
            Console.WriteLine($"Purchase Date: {phone.PurchaseDate}");
            Console.WriteLine($"Purchase Price: {phone.PurchasePrice}");
            Console.WriteLine($"Warranty Months: {phone.WarrantyMonths}");
            Console.WriteLine($"Remaining Warranty Months: {phone.RemainingWarrantyMonths()}");
            Console.WriteLine("-----------------------------");


            Tablet tablet = new Tablet("2023-09-10", 599.99, 18, "Samsung", "10 inches");
            // Output device information            
            Console.WriteLine("Tablet:");
            Console.WriteLine($"Brand: {tablet.Brand}");
            Console.WriteLine($"Screen Size: {tablet.ScreenSize}");
            Console.WriteLine($"Purchase Date: {tablet.PurchaseDate}");
            Console.WriteLine($"Purchase Price: {tablet.PurchasePrice}");
            Console.WriteLine($"Warranty Months: {tablet.WarrantyMonths}");
            Console.WriteLine($"Remaining Warranty Months: {tablet.RemainingWarrantyMonths()}");

            Console.ReadLine();

        }
    }
}
