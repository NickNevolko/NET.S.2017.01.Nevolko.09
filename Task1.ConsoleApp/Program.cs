using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookListStorage = new BookListStorage("BookFile");
            var books = new BookListService();

             
            books.AddBook(new Book(1234, "CLR via C#", "Jeffrey Richter", 2012));
            books.AddBook(new Book(124, "CLR viC#", "Jeffrey Richter", 202));
            books.AddBook(new Book(134, "CLR via C#", "Jeffrey Rihter", 2012));
            books.AddBook(new Book(12, "CLR via C#", "Jeffrey Richter", 2012));
            books.SaveBooks(bookListStorage);

            var book1 = books.FindBookByTag(book => book.Id == 124);

            Console.WriteLine(book1.Id + book1.Name);    
            
        }
    }
}
