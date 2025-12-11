using System;
using System.Linq;
using System.Collections.Generic;
namespace StringList
{

    internal class Program
    {
        static void Main()
        {
            List<string> cities = new List<string>()
        {
            "Pune",
            "Panaji",
            "Patna",
            "Pimpri",
            "Pondicherry",
            "Prayagraj",
            "Delhi",
            "Mumbai"
        };

            var result = from c in cities
                         where c.StartsWith("P") && c.Length > 5
                         select c;

            Console.WriteLine("Cities starting with 'P' and length > 5:");
            foreach (var city in result)
            {
                Console.WriteLine(city);
            }
        }
    }
}

