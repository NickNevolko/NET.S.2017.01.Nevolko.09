using NLog;
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
            ILogging logger = new LogAdapter(LogManager.GetCurrentClassLogger());

            var bookListStorage = new BookListStorage("BookFile");
            var bookListXml = new XmlStorage("file.xml");
            var books = new BookListService(logger);


            //books.AddBook(new Book(1234, "clr via c#", "jeffrey richter", 2012));
            //books.AddBook(new Book(124, "clr vic#", "jeffrey richter", 202));
            //books.AddBook(new Book(134, "clr via c#", "jeffrey rihter", 2012));
            //books.AddBook(new Book(12, "clr via c#", "jeffrey richter", 2012));
            //books.SaveBooks(bookListXml);
              books.LoadBooks(bookListXml);

            var book1 = books.FindBookByTag(book => book.Id == 124);

            Console.WriteLine(book1.Id + book1.Name);    
            
        }
    }
}
