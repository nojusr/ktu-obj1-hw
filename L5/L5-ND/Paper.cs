using System;

namespace L5_ND
{
    /// <summary>
    /// a newspaper class that contains specific information that cannot be found in the parent 'Publication' class
    /// </summary>
    class Paper : Publication
    {

        DateTime Date;
        public int PaperNumber {get; set; }
        public Paper(string title, string publisher, int releaseYear, int pageCount, int releaseCount, DateTime date, int paperNumber)
        {
            this.Type = "paper";
            this.Title = title;
            this.Publisher = publisher;
            this.ReleaseYear = releaseYear;
            this.PageCount = pageCount;
            this.ReleaseCount = releaseCount;

            // paper specific
            this.Date = date;
            this.PaperNumber = paperNumber;
        }

        public override string ToString()
        {
            return String.Format(
                "Laikraštis: {0}, išleido: {1}, data: {2}, puslapiai: {3}, tiražas: {4}, numeris: {5}",
                this.Title,
                this.Publisher,
                this.Date.ToString(),
                this.PageCount,
                this.ReleaseCount,
                this.PaperNumber
            );
        }
    }
}
