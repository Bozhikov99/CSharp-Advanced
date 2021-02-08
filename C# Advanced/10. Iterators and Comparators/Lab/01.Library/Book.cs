using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book
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
    }
}