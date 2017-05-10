using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BinSerializeStorage : IRepository
    {
        private string file;

        BinaryFormatter formatter = new BinaryFormatter();

        public BinSerializeStorage(string file)
        {
            this.file = file;
        }

        public List<Book> LoadBooksList()
        {
            List<Book> deserilizeBooks = new List<Book>();
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                deserilizeBooks = (List<Book>)formatter.Deserialize(fs);
            }
            return deserilizeBooks;
        }

        public void SaveBooksList(IEnumerable<Book> item)
        {

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
