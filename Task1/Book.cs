using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        protected string name;
        public string Name { get; set; }

        protected string author;
        public string Author { get; set; }

        protected int year;
        public int Year { get; set; }

        protected int id;
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book)obj);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode() ^ year ^ id;
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
