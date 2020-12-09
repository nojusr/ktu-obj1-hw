// An implementation of U5_4 by Nojus Raškevičius
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace L5_ND
{
    class IOUtils
    {
        public static LibraryRegister readLibraryRegister(string fileName)
        {
            LibraryRegister output = new LibraryRegister();

            if (File.Exists(fileName) == false)
            {
                throw new Exception(String.Format("Failas {0} neegzistuoja.", fileName));
            }

            int linecount = TotalLines(fileName);

            if (linecount < 4)
            {
                throw new Exception(String.Format("Failas {0} nėra tinkamai formatuotas.", fileName));
            }

            StreamReader sr = new StreamReader(fileName);

            output.LibraryName = sr.ReadLine();
            output.LibraryAddr = sr.ReadLine();
            output.LibraryPhone = sr.ReadLine();

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] split = line.Split(';');

                if (split[0] == "book")
                {
                    output.AddPublication(new Book(
                        split[1],
                        split[2],
                        int.Parse(split[3]),
                        int.Parse(split[4]),
                        int.Parse(split[5]),
                        int.Parse(split[6]),
                        split[7]
                    ));
                }
                else if (split[0] == "journal")
                {
                    output.AddPublication(new Journal(
                        split[1],
                        split[2],
                        int.Parse(split[3]),
                        int.Parse(split[4]),
                        int.Parse(split[5]),
                        int.Parse(split[6]),
                        int.Parse(split[7])
                    ));
                }
                else if (split[0] == "paper")
                {
                    output.AddPublication(new Paper(
                        split[1],
                        split[2],
                        int.Parse(split[3]),
                        int.Parse(split[4]),
                        int.Parse(split[5]),
                        DateTime.Parse(split[6]),
                        int.Parse(split[7])
                    ));
                }
                else
                {
                    throw new Exception(String.Format("Nežinomas leidinio tipas \"{0}\"", split[0]));
                }
            }

            Console.WriteLine("READ FILE: count:{0}",output.AllPublications.Count);
            return output;
        }

        static int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }

        public static void OutputCommonInfo(LibraryRegister reg)
        {
            Publication commonBook = reg.GetMostReleasedBook();
            Publication commonJournal = reg.GetMostReleasedJournal();
            Publication commonPaper = reg.GetMostReleasedPaper();

            Console.WriteLine("{0} (-os) informacija:", reg.LibraryName);
            Console.WriteLine("Numeris: {0}", reg.LibraryPhone);
            Console.WriteLine("Adresas: {0}", reg.LibraryAddr);

            Console.WriteLine("Didžiausio tiražo:");
            Console.WriteLine(commonBook.ToString());
            Console.WriteLine(commonJournal.ToString());
            Console.WriteLine(commonPaper.ToString());
            Console.WriteLine("-----------------------------");
        }

        public static void OutputPublicationsToCSV(string fileName, string header, List<Publication> pubs)
        {
            List<string> lines = new List<string>();

            lines.Add(header);

            foreach (Publication p in pubs)
            {
                lines.Add(p.ToString());
            }

            File.WriteAllLines(fileName, lines);
        }
    }
}
