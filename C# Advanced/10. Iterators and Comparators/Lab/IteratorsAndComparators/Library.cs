using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library: IEnumerable<Book>
    {
        private readonly SortedSet<Book> books;
        public Library(params Book[] books)
        {
            SortedSet<Book> bookList = new SortedSet<Book>(books, new BookComparator());
            this.books = bookList;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int index = -1;
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.books = new List<Book>(books);
            }

            public Book Current => books[index];

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                return ++index < books.Count;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}