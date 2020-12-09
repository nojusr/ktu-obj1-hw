using System;

namespace L5_ND
{
    /// <summary>
    /// a journal class that contains specific information that cannot be found in the parent 'Publication' class
    /// </summary>
    class Journal : Publication
    {

        public int ISBN {get; set;}
        public int JournalNumber {get; set;}

        public Journal(string title, string publisher, int releaseYear, int pageCount, int releaseCount, int _ISBN, int journalNumber)
        {
            this.Type = "journal";
            this.Title = title;
            this.Publisher = publisher;
            this.ReleaseYear = releaseYear;
            this.PageCount = pageCount;
            this.ReleaseCount = releaseCount;

            // journal specific
            this.ISBN = _ISBN;
            this.JournalNumber = journalNumber;
        }

        public override string ToString()
        {
            return String.Format(
                "Žurnalas: {0}, išleido: {1}, metai: {2}, puslapiai: {3}, tiražas: {4}, ISBN: {5}, ž. numeris: {6}",
                this.Title,
                this.Publisher,
                this.ReleaseYear,
                this.PageCount,
                this.ReleaseCount,
                this.ISBN,
                this.JournalNumber
            );
        }
    }
}
