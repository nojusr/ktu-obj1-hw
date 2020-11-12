using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace L4_ND
{
    // an implementation of U4H-3
    class Program
    {
        
        static void Main(string[] args)
        {

            // the known list of delimiters
            List<Char> delimiters = new List<Char>() {';', ',', ' ', '|', '.', '-'};


            // IO filenames
            String inputFile1 = "Knyga1.txt";
            String inputFile2 = "Knyga2.txt";

            String outputFile = "Rodikliai.txt";
            String outputFile2 = "ManoKnyga.txt";


            /*
            * ==================
            * the 'easy' part
            * ==================
            */

            // a list that contains all the words
            List<String> allWords = new List<String>();

            // read in the words individually per file
            List<String> file1Words = InOutUtils.ReadWords(inputFile1, delimiters);
            List<String> file2Words = InOutUtils.ReadWords(inputFile2, delimiters);

            // add both lists to a single list that contains all words
            allWords.AddRange(file1Words);
            allWords.AddRange(file2Words);


            // get the longest words in 'allWords'
            List<String> longestWords = TaskUtils.FindLongestWords(allWords);

            // get the counts for each file of every longest word
            List<int> file1Counts = TaskUtils.GetWordCountList(file1Words, longestWords);
            List<int> flie2Counts = TaskUtils.GetWordCountList(file2Words, longestWords);

            // output the above to both console and file
            InOutUtils.OutputWordCountToConsole(file1Counts, flie2Counts, longestWords);
            InOutUtils.OutputWordCountToFile(outputFile, file1Counts, flie2Counts, longestWords);


            // get all of the words that can only be found in the first file
            List<String> file1UWords = TaskUtils.GetUniqueWords(file1Words, file2Words);

            // get the longest words from the list above
            List<String> file1ULongWords = TaskUtils.FindLongestWords(file1UWords);
            //file1ULongWords.Reverse(); // reverse the longest words, since the task demands it

            // get the word count 
            List<int> file1UCounts = TaskUtils.GetWordCountList(file1Words, file1ULongWords);

            // output the above to both console and file
            InOutUtils.OutputSmallWordCountToConsole(file1UCounts, file1ULongWords);
            InOutUtils.OutputSmallWordCountToFile(outputFile, file1UCounts, file1ULongWords);


            /*
            * ==================
            * the 'hard' part
            * ==================
            */

            String hardPartOutput = TaskUtils.CopyAndCombineBothFiles(inputFile1, inputFile2, delimiters);
            File.WriteAllLines(outputFile2, hardPartOutput.Split('\n'), Encoding.UTF8);
        }
    }
}
