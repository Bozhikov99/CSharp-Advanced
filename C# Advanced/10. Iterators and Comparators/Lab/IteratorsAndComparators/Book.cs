using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book: IComparable<Book>
    {
        public int Year { get; set; }
        public string Title { get; set; }
        public IReadOnlyList<string> Authors { get; set; }

        public Book(string title, int year, params string[] authors)
        {
            Year = year;
            Title = title;
            Authors = authors;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }

        public int CompareTo(Book other)
        {
            int result = Title.CompareTo(other.Title);
            if (result==0)
            {
                return other.Year.CompareTo(Year);
            }
            return result;
        }

        
    }
}