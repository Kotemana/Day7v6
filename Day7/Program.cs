using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("data.json");
            var catCafe = JsonSerializer.Deserialize<CatCafe>(json);
            //catCafe.Report();
            //catCafe.ShowSmallestCat();
            catCafe.ShowFatCats(3500);
        }
    }

    public class CatCafe
    {
        public string Name { get; set; }

        public Address Address { get; set; }
        public List<Cat> Cats { get; set; }

        public void ShowFatCats(int fatWeight)
        {
            var fatCats = Cats.Where(x => x.Weight > fatWeight).ToList();
            Console.WriteLine($"total weight of fatcats: {fatCats.Sum(x => x.Weight)}");
            fatCats.ForEach(x => Console.WriteLine(x.Name));
        }

        public void ShowSmallestCat()
        {
            Console.WriteLine("And the winner is: ........... ....");
            var timer = new Stopwatch();
            timer.Start();
            var smallestCat = new Cat();
            for (int i = 0; i < 1000000; i++)
            {
                smallestCat = GetSmallestCatLinq();
            }

            Console.WriteLine(timer.ElapsedMilliseconds);
            Console.WriteLine(smallestCat.Name);
            
        }
        public Cat GetSmallestCatLinq()
        {
            var weight = Cats.Min(x => x.Weight);
            return Cats.FirstOrDefault(x=>x.Weight == weight);
        }
        public Cat GetSmallestCatFor()
        {
            if (Cats.Count == 1)
            {
                return Cats[0];
            }
            var smallestcat = Cats[0];
            for (int i = 1; i < Cats.Count; i++)
            {
                if (Cats[i].Weight < smallestcat.Weight)
                {
                    smallestcat = Cats[i];
                }
            }
            return smallestcat;
        }
        public void Report()
        {

            //var dogs = new List<string>() { "bobik", "barbos","raida", "tolyasik" };
            //string megaDogName = string.Empty;//""
            //dogs.ForEach(x => megaDogName += x);
            //Console.WriteLine(megaDogName);
            Console.WriteLine($"This is cafe {Name}, located in {Address.City} ({Address.AddressLine})");
            Cats.ForEach(cat => Console.WriteLine($"{cat.Name} has weight of {cat.Weight}."));
        }
    }

    public class Address
    {
        public string City { get; set; }
        public string AddressLine { get; set; }
    }

    public class Cat
    {
        public string Name { get; set; }
        public int Weight { get; set; }

    }
}
