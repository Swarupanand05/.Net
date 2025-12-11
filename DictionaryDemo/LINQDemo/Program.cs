using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LINQDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> {10,2,30,4,55,60,7,8};

            //Find all even numbers using LINQ.
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even Numbers:");
            foreach (var n in evenNumbers)
            {
                Console.WriteLine(n);
            }

            //Find the minimum,MAximum & Average of number using LINQ.
            Console.WriteLine($"Max = {numbers.Max()}, \nMin = {numbers.Min()}, \nAverage = {numbers.Average():F2}");

            //Display numbers greater than 20 sorted descending.
            var greaterThan20 = numbers.Where(n => n > 20).OrderByDescending(n => n);
            Console.WriteLine("Numbers greater than 20 sorted descending:");
            foreach (var n in greaterThan20)
            {
                Console.WriteLine(n);
            }





        }
    }
}
