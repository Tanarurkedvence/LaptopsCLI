using System.Diagnostics.Metrics;

namespace LaptopsCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
             List<Laptop> laptops = new List<Laptop>();
            using (StreamReader o = new StreamReader("../../../forras/laptops.txt"))
            {
                o.ReadLine();
                while(!o.EndOfStream)
                {
                    string line = o.ReadLine();
                    laptops.Add(new Laptop(line));
                }
            }
            foreach (var line in laptops)
            {
                Console.WriteLine(line.ToString());
            }
            int counter = 1;
            Console.WriteLine("6. feladat");
            var f6 = laptops.Where(x => x.CPU.Contains("Intel Core i7") 
            && x.Storage.Contains("SSD"));
 

            foreach (var l in f6)
            {
                Console.WriteLine($"[{counter++}] {l.Category.CategoryName} | {l.Manufacturer.ManufacturerName} {l.Model} | {l.OS}");
            }
            Console.WriteLine("A laptopok átlag ára: "+f6.Average(x => x.Price )+ " INR");
            Console.WriteLine("7. feladat - Fájlba írás");

            var f7 = laptops.Where(x => x.Category.CategoryName == "Gaming").OrderBy(x => x.Price).Take(20);

            using (StreamWriter i = new StreamWriter("../../../forras/cheap.txt"))
            {
                  foreach (var l in f7)
                {
                    i.WriteLine($"{l.Manufacturer.ManufacturerName} {l.Model}\n" +
                    $"\t\t {l.CPU}\n" +
                    $"\t\t {l.Storage}\n" +
                    $"\t\t {l.Screen}\n");
                }
            }
        }
    }
}
