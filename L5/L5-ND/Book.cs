using System;

namespace L5_ND
{
    class Book : Publication
    {
        public int ISBN {get; set;}
        public string Author {get; set;}

        public Book(string title, string publisher, int releaseYear, int pageCount, int releaseCount, int _ISBN, string author)
        {
            this.Type = "book";
            this.Title = title;
            this.Publisher = publisher;
            this.ReleaseYear = releaseYear;
            this.PageCount = pageCount;
            this.ReleaseCount = releaseCount;

            // book specific
            this.ISBN = _ISBN;
            this.Author = author;
        }

        public override string ToString()
        {
            return String.Format(
                "Knyga: {0}, išleido: {1}, metai: {2}, puslapiai: {3}, tiražas: {4}, ISBN: {5}, autorius: {6}",
                this.Title,
                this.Publisher,
                this.ReleaseYear,
                this.PageCount,
                this.ReleaseCount,
                this.ISBN,
                this.Author
            );
        }
        
    }
}
