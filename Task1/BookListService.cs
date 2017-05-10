using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookListService
    {
        ILogging logger;
        private List<Book> booklist;
        public List<Book> BookList
        {
            get { return booklist; }
        }


        public BookListService(ILogging logger)
        {
            this.logger = logger;
            booklist = new List<Book>();
            logger.Debug("1 param BookListService created");
        }

        public BookListService(List<Book> booklist, ILogging logger)
        {
            this.logger = logger;
            this.booklist = booklist;
            logger.Debug("2 param BookListService created");
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                logger.Error("book instance is null");
                throw new ArgumentNullException(nameof(book));              
            }
            if (booklist.Contains(book))
            {
                logger.Error("The same book tried to adding");
                throw new ArgumentException("Book contains yet");
            }           
            booklist.Add(book);
            logger.Debug("book has been added");

        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                logger.Error("trying to remove the null");
                throw new ArgumentNullException(nameof(book));
            }
            if (!booklist.Contains(book))
            {
                logger.Error("trying to remove not existing book");
                throw new ArgumentException("Book doesn't exist");
            }
            logger.Debug("book has been removed");
            booklist.Remove(book);
           
        }

        public Book FindBookByTag(Predicate<Book> predicate)
        {
            logger.Info("finding a book by tag");
            return booklist.Find(predicate);
        }

        public IEnumerable<Book> SortBooksByTag(Func<Book, object> comparer)
        {
            logger.Info("sorting the books by tag");
            return booklist.OrderBy(comparer);
        }

        public void SaveBooks(IRepository saver)
        {
            if (ReferenceEquals(saver, null)) throw new ArgumentNullException(nameof(saver));
            logger.Info("saving the books");
            saver.SaveBooksList(booklist);
        }

        public void LoadBooks(IRepository loader)
        {
            if (ReferenceEquals(loader, null)) throw new ArgumentNullException(nameof(loader));

            logger.Info("loading the books");
            booklist = (List<Book>)loader.LoadBooksList();
        }

    }
}
