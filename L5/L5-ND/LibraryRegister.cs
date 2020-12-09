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

        public List<Publication> GetAllBooks()
        {
            List<Publication> output = new List<Publication>();

            foreach (Publication pub in this.AllPublications)
            {
                Console.WriteLine("PUBTYPE: {0}", pub.Type);
                if (pub.Type == "book")
                {
                    output.Add(pub);
                }
            }

            return output;
        }

        public bool ContainsPublication(Publication pub)
        {
            foreach (Publication localPub in this.AllPublications)
            {
                if (pub.Title == localPub.Title)
                {
                    return true;
                }
            }
            return false;
        }

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


        public Publication GetMostReleasedBook()
        {
            List<Publication> allBooks = this.GetAllBooks();
            Console.WriteLine("BOOKCOUNT: {0}", allBooks.Count);
            return this.GetMostReleasedPub(allBooks);
        }

        public Publication GetMostReleasedJournal()
        {
            List<Publication> allJournals = this.GetAllJournals();
            return this.GetMostReleasedPub(allJournals);
        }

        public Publication GetMostReleasedPaper()
        {
            List<Publication> allPapers = this.GetAllPapers();
            return this.GetMostReleasedPub(allPapers);
        }

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
