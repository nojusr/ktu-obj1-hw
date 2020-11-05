//InOutUtils.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace L4_ND
{
    /// <summary>
    /// Class containing reading and priniting methods
    /// </summary>
    static class InOutUtils
    {

        /// <summary>
        /// a method to read a given filename and return a list of strings
        /// that are seperated by a given list of seperating characters
        /// </summary>
        /// <param name="fileName">the filename, from which to read</param>
        /// <param name="seperators">a list of delimiter characters</param>
        /// <returns>a list of strings</returns>
        public static List<String> ReadWords(string fileName, List<Char> seperators){

            List<String> output = new List<String>();

            StreamReader file;
            string line;

            // file error handling
            if (System.IO.File.Exists(fileName))
            {
                file = new StreamReader(fileName);
            }
            else
            {
                Console.WriteLine("Failas nerastas. Programa negali veikti.");
                System.Environment.Exit(1); // exit code 1 means that the program did not run successfuly
                return output; // an useless line of code to calm down the error highlighter, wihtout it, the 'while' statement below would be registered as an error
            }

            // for each line in a file
            while ((line = file.ReadLine()) != null)
            {

                if (line.Length == 0)
                {
                    continue;
                }

                // convert the line to lowercase due to task requirements
                line = line.ToLower();

                // an index that indicates the last known position of a delimiting character
                int wordStartIndex = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    if (seperators.Contains(line[i]))
                    {

                        String word;


                        // if we're on the first word in the sequence
                        if (wordStartIndex == 0)
                        {
                            // don't remove the first character from the substring
                            word = line.Substring(wordStartIndex, i-wordStartIndex);
                        } 
                        else
                        {
                            // remove the first character from the substring
                            word = line.Substring(wordStartIndex+1, i-wordStartIndex-1);
                        }

                        output.Add(word);

                        wordStartIndex = i;
                    }
                }

                // if the last character in a line is not a delimiter
                if (seperators.Contains(line[line.Length-1]) == false)
                {
                    // add the remaining word that was undetected in the loop above
                    String word;

                    // if this is true, then the whole line doesn't have any delimiters
                    if (wordStartIndex == 0)
                    {
                        word = line;
                    } 
                    else
                    {
                        // remove the first character from the substring
                        word = line.Substring(wordStartIndex+1, line.Length-wordStartIndex-1);
                    }

                    output.Add(word);
                }
            }

            return output;
        }


        /// <summary>
        ///  a simple method to assist in creating text character based tables
        /// </summary>
        /// <param name="spacing">a list of ints which defines the amount of <paramref name="line"/> chars to put in between any of the other chars</param>
        /// <param name="columnCount">the amount of columns in the</param>
        /// <param name="leftEdge">the char used at the left edge of the table</param>
        /// <param name="middleEdge">the char used inbetween lines</param>
        /// <param name="rightEdge">the char used at the right edge or end of the line</param>
        /// <param name="line">the char used inbetween any and all other chars</param>
        private static string CreateIndexedTableLine(List<int> spacing, char leftEdge, char middleEdge, char rightEdge, char line)
        {

            int columnCount = spacing.Count;

            string output = "";

            output += leftEdge;

            for (int i = 0; i < columnCount; i++) {

                output += new string(line, spacing[i]);

                if (i == columnCount - 1)
                {
                    output += rightEdge;
                }
                else
                {
                    output += middleEdge;
                }
            }

            return output;
        }


        /// <summary>
        /// outputs a table of the word count to a file
        /// </summary>
        public static void OutputWordCountToFile(String fileName, List<int> file1Count, List<int> file2Count, List<String> words)
        {
            List<String> output = CreateWordCountTable(file1Count, file2Count, words);
            File.WriteAllLines(fileName, output.ToArray(), Encoding.UTF8);
        }

        /// <summary>
        /// outputs a table of the word count to console
        /// </summary>
        public static void OutputWordCountToConsole(List<int> file1Count, List<int> file2Count, List<String> words)
        {
            List<String> output = CreateWordCountTable(file1Count, file2Count, words);
            Console.WriteLine(String.Join("\n", output));

        }


        /// <summary>
        /// creates a table to display the word count for the longest words from the input.
        /// used both in console output and file output
        /// </summary>
        /// <param name="file1Count">a list of integers</param>
        /// <param name="file2Count">a list of integers</param>
        /// <param name="words">a list of strings</param>
        /// <returns>the table as a list of strings</returns>
        private static List<String> CreateWordCountTable(List<int> file1Count, List<int> file2Count, List<String> words)
        {

            List<String> output = new List<String>();


            List<int> tableSpacing = new List<int> {6, 6, 20};

            string topstr = CreateIndexedTableLine(tableSpacing, '┌', '┬', '┐', '─');
            string midstr = CreateIndexedTableLine(tableSpacing, '├', '┼', '┤', '─');
            string botstr = CreateIndexedTableLine(tableSpacing, '└', '┴', '┘', '─');

            output.Add(topstr);
            output.Add(String.Format(
                "│{0,-6}│{1,-6}│{2, -20}│",
                "Knyga1",
                "Knyga2",
                "Žodis"
            ));
            output.Add(midstr);


            for (int i = 0; i < words.Count; i++)
            {
                output.Add(String.Format(
                    "│{0,-6}│{1,-6}│{2, -20}│",
                    file1Count[i].ToString(),
                    file2Count[i].ToString(),
                    words[i]
                ));
            }

            output.Add(botstr);

            return output;
        }





        public static void OutputSmallWordCountToFile(String fileName, List<int> file1Count, List<String> words)
        {
            List<String> output = CreateSmallWordCountTable(file1Count, words);
            File.AppendAllLines(fileName, output.ToArray(), Encoding.UTF8);
        }

        /// <summary>
        /// outputs a table of the word count to console
        /// </summary>
        public static void OutputSmallWordCountToConsole(List<int> file1Count, List<String> words)
        {
            List<String> output = CreateSmallWordCountTable(file1Count, words);
            Console.WriteLine(String.Join("\n", output));

        }



        private static List<String> CreateSmallWordCountTable(List<int> file1Count, List<String> words)
        {

            List<String> output = new List<String>();


            List<int> tableSpacing = new List<int> {6, 20};

            string topstr = CreateIndexedTableLine(tableSpacing, '┌', '┬', '┐', '─');
            string midstr = CreateIndexedTableLine(tableSpacing, '├', '┼', '┤', '─');
            string botstr = CreateIndexedTableLine(tableSpacing, '└', '┴', '┘', '─');

            output.Add(topstr);
            output.Add(String.Format(
                "│{0,-6}│{1, -20}│",
                "Knyga1",
                "Žodis"
            ));
            output.Add(midstr);


            for (int i = 0; i < words.Count; i++)
            {
                output.Add(String.Format(
                    "│{0,-6}│{1, -20}│",
                    file1Count[i].ToString(),
                    words[i]
                ));
            }

            output.Add(botstr);

            return output;
        }







    }
}
