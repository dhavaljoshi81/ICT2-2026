using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS
{
    internal class LINQDemos
    {
        static void Main1(string[] args)
        {
            int[] numbers = { 10, 23, 45, 67, 89, 12, 34, 56, 78, 90 };

            // Using LINQ to filter even numbers
            var evenNumbers = from num in numbers
                              where num % 2 == 0
                              select num;

            Console.WriteLine("Even Numbers:");
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }

            // Using LINQ to find numbers greater than 50
            var greaterThanFifty = numbers.Where(n => n > 50);

            Console.WriteLine("\nNumbers Greater Than 50:");
            foreach (var num in greaterThanFifty)
            {
                Console.WriteLine(num);
            }
        }

        static void Main2(string[] args)
        {
            int[] numbers = { 10, 23, 45, 67, 89, 12, 34, 56, 78, 90 };

            //var data = from n in numbers
            //           where n > 50
            //           select n;

            //data = numbers.Where(a => a > 50);

            Console.WriteLine("Ang : " + numbers.Average());

            var data = from n in numbers
                       where n > numbers.Where(a => a > 50).Average()
                       select n;

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

        }

        static void Main3(string[] args)
        {
            int[] numbers = { 10, 23, 45, 10, 67, 89, 12 };
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=====Distinct======");

            var newData = numbers.Distinct();
            foreach (var item in newData)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=====OrderBy======");

            var newData1 = numbers.OrderBy(a => a);
            foreach (var item in newData1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=====Union======");

            int[] values = { 33, 12, 44, 16, 10, 12, 67 };

            var newData2 = numbers.Union(values);

            foreach (var item in newData2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=====Intersect======");

            var newData3 = numbers.Intersect(values);

            foreach (var item in newData3)
            {
                Console.WriteLine(item);
            }
        }

        static void Main4(string[] args)
        {
            string[] names = {"Rajan", "Aarohi",
                "Mathuradas", "Rajat", "Roshni", "Shivani",
                "Umesh", "Suresh", "Tarika"};

            var data = from n in names
                       where n.StartsWith("R") && n.Length > 4
                       select n;
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----Using Lambda------");
            var data2 = names.Where(a => a.StartsWith("R") && a.Length > 4);
            foreach (var item in data2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Lengths of Names: ");
            
            var data3 = names.Select(a => a.Length);
            
            foreach (var item in data3)
            {
                Console.WriteLine(item);
            }
        }

        static void Main5(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { ID = 1, Name = "Computer", Rate = 50000, Category="Electronics", Description = "For Office use." });
            products.Add(new Product { ID = 2, Name = "Table", Rate = 5500, Category = "Furniture", Description = "For Office use." });
            products.Add(new Product { ID = 3, Name = "Chair", Rate = 3300, Category = "Furniture", Description = "For Office use." });
            products.Add(new Product { ID = 4, Name = "Laptop", Rate = 65000, Category = "Electronics", Description = "For Office use." });
            products.Add(new Product { ID = 5, Name = "Printer", Rate = 34000, Category = "Electronics", Description = "For Office use." });

            //var result = from p in products
            //             where p.Category.Contains("Furniture")
            //             select p;

            //var result = from p in products
            //             where p.Name.Contains("a")
            //             select p;

            //var result = from p in products
            //             where p.Rate > 1000 && p.Rate < 40000
            //                && p.Name.Contains("r")
            //             select p;

            //var result = products.Where(p => p.Rate > 1000)
            //    .Where(p => p.Rate < 40000)
            //    .Where(p => p.Name.Contains("r"));

            var result = products.Where(p => p.Rate > 1000 
                            && p.Rate < 40000 
                            && p.Name.Contains("r"));

            foreach (var item in result)
            {
                item.Display();
            }
        }

    }
}
