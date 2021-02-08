using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int count = -1;
        public LibraryIterator(List<Book> books)
        {
            this.books = books;
        }

        public Book Current => books[count];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            count++;
            return count < books.Count;
        }

        public void Reset()
        {
            count=-1;
        }
    }
}