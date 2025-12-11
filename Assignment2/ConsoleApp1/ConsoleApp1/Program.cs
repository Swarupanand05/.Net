using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                 new Book(1, "C# in Depth", "Jon Skeet", 750),
                 new Book(2, "Pro ASP.NET Core", "Adam Freeman", 600),
                 new Book(3, "Clean Code", "Robert C. Martin", 450),
                 new Book(4, "The Pragmatic Programmer", "Andrew Hunt", 500),
                 new Book(5, "Design Patterns", "Erich Gamma", 650),
                 new Book(6, "Head First Design", "Eric Freeman", 350),
                 new Book(7, "Algorithms", "Robert Sedgewick", 800),
                 new Book(8, "Introduction to Algorithms", "Thomas H. Cormen", 900),
                 new Book(9, "Refactoring", "Martin Fowler", 550),
                 new Book(10, "Programming Pearls", "Jon Bentley", 300)
            };
            //Display All books by descending order of price
            Console.WriteLine("All books by descending order of price");
           books.Sort((x, y) => y.price.CompareTo(x.price));
            foreach (var item in books)
            {
                item.Display();
            }


            //Display all books where Author name contains letter 'a'
            Console.WriteLine("all books where Author name contains letter 'a'");
            Console.WriteLine("booklist list");
            foreach (var item in books)
            {
                //item.Display();
                if (item.author.Contains("a", StringComparison.OrdinalIgnoreCase))
                    item.Display();
            }
            //Remove a book whose Id is given by user.
            Console.WriteLine();
            Console.WriteLine("Enter book id to remove:");
            int id = Convert.ToInt32(Console.ReadLine());
            Book bookToRemove = books.Find(b => b.id == id);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine($"Book with ID {id} removed.");
            }
            else
            {
                Console.WriteLine($"Book with ID {id} not found.");
            }
            foreach (var item in books)
            {
                item.Display();
            }






        }

    }
}
class Book
{
    public int id { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public int price { get; set; }

    public Book(int id, string title, string author, int price)
    {
        this.id = id;
        this.title = title;
        this.author = author;
        this.price = price;
    }
    public void Display()
    {
        Console.WriteLine($"ID: {id}, Title: {title}, Author: {author}, Price: {price}");
    }
}