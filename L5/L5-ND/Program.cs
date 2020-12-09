// An implementation of U5_4 by Nojus Raškevičius
using System;
using System.Collections.Generic;

namespace L5_ND
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // variables
            string SpecificPubName = "Technologija";

            LibraryRegister reg1 = IOUtils.readLibraryRegister("kaunas.txt");
            LibraryRegister reg2 = IOUtils.readLibraryRegister("kaunas2.txt");
            LibraryRegister reg3 = IOUtils.readLibraryRegister("vilnius.txt");

            // output the most common book in each library
            IOUtils.OutputCommonInfo(reg1);
            IOUtils.OutputCommonInfo(reg2);
            IOUtils.OutputCommonInfo(reg3);
        
            // output the rarest book from all libraries
            List<Publication> GlobalPublications = new List<Publication>();
            GlobalPublications.AddRange(reg1.AllPublications);
            GlobalPublications.AddRange(reg2.AllPublications);
            GlobalPublications.AddRange(reg3.AllPublications);

            List<Publication> UniquePublications = new List<Publication>();

            for (int i = 0; i < GlobalPublications.Count; i++)
            {
                bool IsUnique = true;
                for (int j = 0; j < GlobalPublications.Count; j++)
                {
                    if (GlobalPublications[i].Title == GlobalPublications[j].Title && i != j)
                    {
                        IsUnique = false;
                    }
                }

                if (IsUnique)
                {
                    UniquePublications.Add(GlobalPublications[i]);
                }
            }

            IOUtils.OutputPublicationsToCSV("RetiLeidiniai.csv", "Reti leidiniai:", UniquePublications);


            // output all books from a specific publisher, sort before outputting
            List<Publication> SpecificPublisherPubs = new List<Publication>();
            SpecificPublisherPubs.AddRange(reg1.GetPubsFromSpecificPublisher(SpecificPubName));
            SpecificPublisherPubs.AddRange(reg2.GetPubsFromSpecificPublisher(SpecificPubName));
            SpecificPublisherPubs.AddRange(reg3.GetPubsFromSpecificPublisher(SpecificPubName));


            // bubble sort
            for (int i = 0; i < SpecificPublisherPubs.Count; i++)
            {
                for (int j = 0; j < SpecificPublisherPubs.Count-i-1; j++)
                {
                    if (SpecificPublisherPubs[j] > SpecificPublisherPubs[j+1])
                    {
                        Publication buf = SpecificPublisherPubs[j];
                        SpecificPublisherPubs[j] = SpecificPublisherPubs[j+1];
                        SpecificPublisherPubs[j+1] = buf;
                    }
                }
            }

            IOUtils.OutputPublicationsToCSV(
                "Technologija.csv",
                "Visi leidiniai iš leidyklos \"Technologjia\":",
                SpecificPublisherPubs
            );


            // get all publications that can be found in all three libraries, output them
            List<Publication> CommonPublications = new List<Publication>();

            for (int i = 0; i < GlobalPublications.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < GlobalPublications.Count; j++)
                {
                    if (GlobalPublications[i].Title == GlobalPublications[j].Title && i != j)
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    bool contains = false;
                    Publication itemToTest = GlobalPublications[i];

                    // testing is needed for all specific types ofpublication
                    // which is why there is a lot of code below.
                    if (itemToTest.Type == "book")
                    {
                        foreach (Publication t in CommonPublications)
                        {
                            if (t.Type == "book")
                            {
                                Book tBook = t as Book;
                                Book itemBook = itemToTest as Book;

                                if (tBook.ISBN == itemBook.ISBN)
                                {
                                    contains = true;
                                }
                            }
                        }

                    }
                    else if (itemToTest.Type == "journal")
                    {
                        foreach (Publication t in CommonPublications)
                        {
                            if (t.Type == "journal")
                            {
                                Journal tJournal = t as Journal;
                                Journal itemJournal = itemToTest as Journal;

                                if (tJournal.JournalNumber == itemJournal.JournalNumber)
                                {
                                    contains = true;
                                }
                            }
                        }
                    }
                    else if (itemToTest.Type == "paper")
                    {
                        foreach (Publication t in CommonPublications)
                        {
                            if (t.Type == "paper")
                            {
                                Paper tPaper = t as Paper;
                                Paper itemPaper = itemToTest as Paper;

                                if (tPaper.PaperNumber == itemPaper.PaperNumber)
                                {
                                    contains = true;
                                }
                            }
                        }
                    }
                    if (!contains)
                    {
                        CommonPublications.Add(GlobalPublications[i]);
                    }
                }
            }

            IOUtils.OutputPublicationsToCSV(
                "BendriLeidiniai.csv",
                "Bendri leidiniai tarp trijų bibliotekų:",
                CommonPublications
            );

        }
    }
}
