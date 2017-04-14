using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookListService
    {
        
        private List<Book> booklist = new List<Book>();
        public List<Book> BookList
        {
            get { return booklist; }
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException(nameof(book));
            if (booklist.Contains(book))
                throw new ArgumentException("Book contains yet");
            booklist.Add(book);
            
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException(nameof(book));
            if (booklist.Contains(book))
                booklist.Remove(book);
            throw new ArgumentException("Book doesn't exist");
        }

        public Book FindBookByTag(Predicate<Book> predicate)
        {
            return booklist.Find(predicate);
        }

        public IEnumerable<Book> SortBooksByTag(Func<Book, object> comparer)
        {
            return booklist.OrderBy(comparer);
        }

        public void SaveBooks(IRepository saver)
        {
            if (ReferenceEquals(saver, null)) throw new ArgumentNullException(nameof(saver));

            saver.SaveBooksList(booklist);
        }

        public void LoadBooks(IRepository loader)
        {

            if (ReferenceEquals(loader, null)) throw new ArgumentNullException(nameof(loader));
            booklist = (List<Book>)loader.LoadBooksList();
        }

    }
}
