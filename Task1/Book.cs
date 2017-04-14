using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public int Id { get; set; }

        public Book(int id, string name, string author, int year)
        {
            this.Id = id;
            this.Name = name;
            this.Year = year;
            this.Author = author;

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book)obj);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode() ^ Year ^ Id;
        }

        public bool Equals(Book other)
        {
            if (other.GetType() != this.GetType()) return false;
            if (other == null) return false;
            if (ReferenceEquals(this,other)) return true;

            return this.Name == other.Name &&
                   this.Year == other.Year &&
                   this.Author == other.Author &&
                   this.Id == other.Id;
        }

        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return Name.CompareTo(other.Name);
        }
    }
}
