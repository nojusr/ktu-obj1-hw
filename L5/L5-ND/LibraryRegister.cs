using System;
using System.Collections.Generic;


namespace L5_ND
{
    class LibraryRegister
    {

        public string LibraryName {get; set;}
        public string LibraryAddr {get; set;}
        public string LibraryPhone {get; set;}
        public List<Publication> AllPublications;

        public LibraryRegister(List<Publication> allPubs)
        {
            this.AllPublications = new List<Publication>();
            this.AllPublications.AddRange(allPubs);
        }

        public LibraryRegister()
        {
            this.AllPublications = new List<Publication>();
        }

        public void AddPublication(Publication pub)
        {
            this.AllPublications.Add(pub);
        }

        public void AddPublications(List<Publication> pubs)
        {
            this.AllPublications.AddRange(pubs);
        }

        /// <summary>
        /// gets a list of all books that can be found in the library
        /// </summary>
        /// <returns>a list of publications, all of whom are of the 'book' type</returns>
        public List<Publication> GetAllBooks()
        {
            List<Publication> output = new List<Publication>();

            foreach (Publication pub in this.AllPublications)
            {
                if (pub.Type == "book")
                {
                    output.Add(pub);
                }
            }

            return output;
        }

        /// <summary>
        /// gets a list of all journals that can be found in the library
        /// </summary>
        /// <returns>a list of publications all of whom have the 'journal' type</returns>
        public List<Publication> GetAllJournals()
        {
            List<Publication> output = new List<Publication>();

            foreach (Publication pub in this.AllPublications)
            {
                if (pub.Type == "journal")
                {
                    output.Add(pub);
                }
            }

            return output;
        }

        /// <summary>
        /// gets a list of all newspapers that can be found in the library
        /// </summary>
        /// <returns>a list of publications, all of whom have the 'paper' type</returns>
        public List<Publication> GetAllPapers()
        {
            List<Publication> output = new List<Publication>();

            foreach (Publication pub in this.AllPublications)
            {
                if (pub.Type == "paper")
                {
                    output.Add(pub);
                }
            }

            return output;
        }

        /// <summary>
        /// gets a list of publications that are published by a specific publisher
        /// </summary>
        /// <param name="PublisherName">the name of the publisher that is being searched for</param>
        /// <returns>a list of publications</returns>
        public List<Publication> GetPubsFromSpecificPublisher(string PublisherName)
        {
            List<Publication> output = new List<Publication>();

            foreach (Publication pub in this.AllPublications)
            {
                if (pub.Publisher == PublisherName)
                {
                    output.Add(pub);
                }
            }
            return output;
        }

        /// <summary>
        /// gets the book that contains the most amount of copies in the library
        /// </summary>
        /// <returns>a publication of the 'book' type</returns>
        public Publication GetMostReleasedBook()
        {
            List<Publication> allBooks = this.GetAllBooks();

            return this.GetMostReleasedPub(allBooks);
        }
        /// <summary>
        /// gets the journal that contains the most amount of copies in the library
        /// </summary>
        /// <returns>a publication of the 'journal' type</returns>
        public Publication GetMostReleasedJournal()
        {
            List<Publication> allJournals = this.GetAllJournals();
            return this.GetMostReleasedPub(allJournals);
        }
        /// <summary>
        /// gets the newspaper that contains the most amount of copies in the library
        /// </summary>
        /// <returns>a publication of the 'paper' type</returns>
        public Publication GetMostReleasedPaper()
        {
            List<Publication> allPapers = this.GetAllPapers();
            return this.GetMostReleasedPub(allPapers);
        }

        /// <summary>
        /// an internal method used to get the publication with the most amount of copies from a list of publications
        /// </summary>
        /// <param name="pubs">a list of publications</param>
        /// <returns>the publication with the most amount of copies</returns>
        private Publication GetMostReleasedPub(List<Publication> pubs)
        {
            Publication output = pubs[0];

            foreach (Publication pub in pubs)
            {
                if (output.ReleaseCount < pub.ReleaseCount)
                {
                    output = pub;
                }
            }

            return output;
        }
    }
}
