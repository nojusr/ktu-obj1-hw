//InOutUtils.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace L4_ND
{
    /// <summary>
    /// A class containing all of the required methods for completing the given task
    /// </summary>
    static class TaskUtils
    {

        /// <summary>
        /// a method that finds the ten longest words from a given list of words
        /// </summary>
        /// <returns>a list strings</returns>
        public static List<String> FindLongestWords(List<String> input)
        {
            List<String> output = new List<String>();

            for (int i = 0; i < 10; i++)
            {
                String longest = "";

                for (int j = 0; j < input.Count; j++)
                {
                    if (longest.Length < input[j].Length && output.Contains(input[j]) == false)
                    {
                        longest = input[j];
                    }
                }

                // we've run out of words to add
                if (longest == "")
                {
                    break;
                }

                output.Add(longest);
            }

            return output;
        }

        /// <summary>
        /// gets all words that can only be found in the 'left' list of strings
        /// </summary>
        /// <param name="left">a list of strings</param>
        /// <param name="right">a list of strings</param>
        /// <returns>a list of strings</returns>
        public static List<String> GetUniqueWords(List<String> left, List<String> right)
        {
            List<String> output = new List<String>();

            foreach (String lWord in left)
            {
                if (right.Contains(lWord) == false)
                {
                    output.Add(lWord);
                }
            }

            return output;
        }


        /// <summary>
        /// get the count of a word when compared against a list of strings
        /// </summary>
        /// <param name="input">a list of strings to compare against</param>
        /// <param name="wordToCount">the word to get the amount of</param>
        /// <returns>an integer</returns>
        public static int GetWordCount(List<String> input, String wordToCount)
        {
            int output = 0;

            foreach(String s in input)
            {
                if (s == wordToCount)
                {
                    output++;
                }
            }

            return output;
        }

        /// <summary>
        /// get the count of a list of words when comparing against a list of inputs
        /// </summary>
        /// <param name="input">a list of strings to compare against</param>
        /// <param name="wordsToCount">the words to get the amount of</param>
        /// <returns>a list of integers</returns>
        public static List<int> GetWordCountList(List<String> input, List<String> wordsToCount)
        {
            List<int> output = new List<int>();

            foreach(String word in wordsToCount)
            {
                output.Add(GetWordCount(input, word));
            }

            return output;
        }


        /// <summary>
        /// does the hard part
        /// </summary>
        /// <param name="fileName1">the first file from which to read</param>
        /// <param name="fileName2">the second file from which to read</param>
        /// <returns>a long string</returns>
        public static String DoTheHardPart(String fileName1, String fileName2, List<Char> delimiters)
        {
            String output = "";

            // we can read both of the files again without worry since we've already ensured that they both exist in
            // the easy part
            
            String file1 = String.Join("\n", File.ReadAllLines(fileName1));

            String file2 = String.Join("\n", File.ReadAllLines(fileName2));


            int file1ReadIndex = 0;
            int file2ReadIndex = 0;

            int file1LastWordIndex = 0;
            int file2LastWordIndex = 0;

            // true to copy from lines1
            // false to copy from lines2
            bool readToggle = true;

            String cmpOut = "";

            // i can only give you prayers if you are tasked with understanding and trying to decipher the code below.
            // here is a visual metaphor of what's to come:
/*
                      ____                    
                 ____ \__ \
                 \__ \__/ / __
                 __/ ____ \ \ \    ____
                / __ \__ \ \/ / __ \__ \
           ____ \ \ \__/ / __ \/ / __/ / __
      ____ \__ \ \/ ____ \/ / __/ / __ \ \ \
      \__ \__/ / __ \__ \__/ / __ \ \ \ \/
      __/ ____ \ \ \__/ ____ \ \ \ \/ / __
     / __ \__ \ \/ ____ \__ \ \/ / __ \/ /
     \ \ \__/ / __ \__ \__/ / __ \ \ \__/
      \/ ____ \/ / __/ ____ \ \ \ \/ ____
         \__ \__/ / __ \__ \ \/ / __ \__ \
         __/ ____ \ \ \__/ / __ \/ / __/ / __
        / __ \__ \ \/ ____ \/ / __/ / __ \/ /
        \/ / __/ / __ \__ \__/ / __ \/ / __/
        __/ / __ \ \ \__/ ____ \ \ \__/ / __
       / __ \ \ \ \/ ____ \__ \ \/ ____ \/ /
       \ \ \ \/ / __ \__ \__/ / __ \__ \__/
        \/ / __ \/ / __/ ____ \ \ \__/
           \ \ \__/ / __ \__ \ \/
            \/      \ \ \__/ / __
                     \/ ____ \/ /
                        \__ \__/
                        __/
*/


            while (true)
            {


                //Console.WriteLine("flag");

                if (readToggle)
                {
                    while (file1ReadIndex < file1.Length)
                    {
                        //Console.WriteLine("l1test");


                        if (delimiters.Contains(file1[file1ReadIndex]))
                        {


                            String word = file1.Substring(file1LastWordIndex, file1ReadIndex-file1LastWordIndex);
                            //Console.WriteLine("FoundWord! {0}", word);

                            if (word.Length <= 0)
                            {
                                file1LastWordIndex++;
                                file1ReadIndex++;
                            }
                            

                            String strippedWord = word;

                            

                            if (strippedWord.Length > 0 && delimiters.Contains(word[0]))
                            {
                                strippedWord = word.Substring(1);
                            }

                            strippedWord = strippedWord.Replace("\n", "").Replace("\r", "");

                            //Console.WriteLine("Stripped: {0}", strippedWord);
                            

                            String firstUncopiedWord = findFirstUncopiedWord(file2, file2ReadIndex, delimiters);

                            if (strippedWord == firstUncopiedWord){
                                //Console.WriteLine("OH SHIT WE SWITCHIN");

                                if (word.Length > 0 && delimiters.Contains(word[0]))
                                {
                                    output += word[0];
                                }

                                readToggle = !readToggle;
                                file1LastWordIndex = file1ReadIndex;
                                break;
                            }

                            output += word;

                            file1LastWordIndex = file1ReadIndex;
                            //Console.WriteLine("----------------------");
                        }
                        file1ReadIndex++;
                    }
                }
                else
                {
                    while (file2ReadIndex < file2.Length)
                    {
                        //Console.WriteLine("l2test");

                        if (delimiters.Contains(file2[file2ReadIndex]))
                        {


                            String word = file2.Substring(file2LastWordIndex, file2ReadIndex-file2LastWordIndex);
                            //Console.WriteLine("FoundWord! {0}", word);
                            
                            if (word.Length <= 0)
                            {
                                file2LastWordIndex++;
                                file2ReadIndex++;
                            }


                            String strippedWord = word;

                            

                            if (strippedWord.Length > 0 && delimiters.Contains(word[0]))
                            {
                                strippedWord = word.Substring(1);
                            }

                            strippedWord = strippedWord.Replace("\n", "").Replace("\r", "");

                            //Console.WriteLine("Stripped: {0}", strippedWord);

                            String firstUncopiedWord = findFirstUncopiedWord(file1, file1ReadIndex, delimiters);


                            if (strippedWord == firstUncopiedWord){
                                //Console.WriteLine("OH SHIT WE SWITCHIN");

                                if (word.Length > 0 && delimiters.Contains(word[0]))
                                {
                                    output += word[0];
                                }

                                readToggle = !readToggle;
                                file2LastWordIndex = file2ReadIndex;
                                break;
                            }

                            output += word;

                            //Console.WriteLine("----------------------");
                            file2LastWordIndex = file2ReadIndex;
                        }
                        file2ReadIndex++;
                    }
                }
                
                // a check to see if we're finished
                if (output == cmpOut)
                {
                    break;
                }
                else
                {
                    cmpOut = output;
                }

            }

            return output;

        }

        public static String findFirstUncopiedWord(String file, int readIndex, List<Char> delimiters)
        {
            String output = "";

            int lastWordIndex = readIndex;

            if (delimiters.Contains(file[readIndex])){
                readIndex++;
            }

            while (readIndex < file.Length)
            {
                
                //Console.WriteLine("readindex: {0}, filelen: {1}", readIndex.ToString(), file.Length.ToString());

                if (delimiters.Contains(file[readIndex]))
                {
                    String word = file.Substring(lastWordIndex, readIndex-lastWordIndex);

                    //Console.WriteLine("FoundFirstUncopiedWord! {0}", word);

                    word = word.Trim();
                    word = word.Replace("\n", "").Replace("\r", "");


                    if (word.Length > 0 && delimiters.Contains(word[0]))
                    {
                        word = word.Substring(1);
                    }

                    ////Console.WriteLine("strippedFirstWord: {0}", word);
                    return word;
                }

                readIndex++;

            }

            return output;

        }


    }
}