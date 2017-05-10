using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BookListStorage : IRepository
    {
        private string file;

        public BookListStorage(string file)
        {
            this.file = file;
        }

        public List<Book> LoadBooksList()
        {
            var list = new List<Book>();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read), Encoding.UTF8))
                {

                    while (reader.PeekChar() > -1)
                    {
                        list.Add(new Book(reader.ReadInt32(), reader.ReadString(), reader.ReadString(), reader.ReadInt32()));
                    }
                }
            }
            catch (IOException)
            {
                throw new IOException("IO Error");
            }
           
            return list;
        }


        public void SaveBooksList(IEnumerable<Book> item)
        {
            try
            {
                using (BinaryWriter fil = new BinaryWriter(File.Open(file, FileMode.OpenOrCreate, FileAccess.Write), Encoding.UTF8))
                {
                    foreach (var elem in item)
                    {
                        fil.Write(elem.Id);
                        fil.Write(elem.Name);
                        fil.Write(elem.Author);
                        fil.Write(elem.Year);
                    }
                }

            }
            catch (IOException)
            {
                throw new IOException("IO Error");
            }
        }
    }
}
