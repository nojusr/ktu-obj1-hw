using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace L5_ND
{
    class IOUtils
    {
        /// <summary>
        /// creates a libraryRegister from an input file
        /// </summary>
        /// <param name="fileName">the input filename</param>
        /// <returns>a libraryRegister</returns>
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

            return output;
        }


        /// <summary>
        /// gets the total amount of lines in a text file
        /// </summary>
        /// <param name="filePath">the text file to test</param>
        /// <returns>the line count</returns>
        private static int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }

        /// <summary>
        /// outputs info about a libraryRegister and the most common publication in all three publication types
        /// </summary>
        /// <param name="reg">the libraryRegister as input</param>
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

        /// <summary>
        /// outputs a list of publications to a CSV file
        /// </summary>
        /// <param name="fileName">the file to which to output</param>
        /// <param name="header">a string that is put before the list of publications</param>
        /// <param name="pubs">a list of publications</param>
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
