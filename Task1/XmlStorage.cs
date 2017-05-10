using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task1
{
    public class XmlStorage : IRepository
    {
        private string file;

        public XmlStorage(string file)
        {
            this.file = file;
        }

        public List<Book> LoadBooksList()
        {
            List<Book> resList = new List<Book>();

            XDocument xdoc = XDocument.Load(file);

            foreach (var item in xdoc.Element("BookList").Elements("Book"))
            {
                XElement id = item.Element("id");
                XElement name = item.Element("name");
                XElement author = item.Element("author");
                XElement year = item.Element("year");

                resList.Add(new Book(int.Parse(id.Value), name.Value, author.Value, int.Parse(year.Value)));
            }
            return resList;
        }

        public void SaveBooksList(IEnumerable<Book> item)
        {
            XDocument document = new XDocument();

            document.Add(new XElement("BookList"));

            foreach (var book in item)
            {
                XElement node = new XElement("Book");

                XElement id = new XElement("id", book.Id);
                XElement name = new XElement("name", book.Name);
                XElement author = new XElement("author", book.Author);
                XElement year = new XElement("year", book.Year);

                node.Add(id, name, author, year);

                document.Root.Add(node);

            }
            document.Save(file);
        }
    }
}
