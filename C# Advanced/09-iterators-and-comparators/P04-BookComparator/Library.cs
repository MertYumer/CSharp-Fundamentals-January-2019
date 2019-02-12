namespace P04_BookComparator
{
    using System.Collections.Generic;
    using System.Collections;

    public class Library : IEnumerable<Book>
    {
        private readonly List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            this.books.Sort(new BookComparator());
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private IReadOnlyList<Book> books;
            private int currentIndex;

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose() { }

            public bool MoveNext() => ++currentIndex < this.books.Count;

            public void Reset() => this.currentIndex = -1;
        }
    }
}
