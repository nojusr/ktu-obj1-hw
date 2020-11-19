//TaskUtils.cs
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
                string longest = "";

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

            foreach (string lWord in left)
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
        public static int GetWordCount(List<String> input, string wordToCount)
        {
            int output = 0;

            foreach(string s in input)
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

            foreach(string word in wordsToCount)
            {
                output.Add(GetWordCount(input, word));
            }

            return output;
        }


        /// <summary>
        /// copies and writes both files into a string, according to the specification in the 'hard' part of the
        /// given task
        /// </summary>
        /// <param name="fileName1">the first file from which to read</param>
        /// <param name="fileName2">the second file from which to read</param>
        /// <returns>a long string</returns>
        public static string CopyAndCombineBothFiles(string fileName1, string fileName2, List<Char> delimiters)
        {
            string output = "";

            // we can read both of the files again without worry since we've already ensured that they both exist in
            // the easy part
            
            string file1 = String.Join("\n", File.ReadAllLines(fileName1));

            string file2 = String.Join("\n", File.ReadAllLines(fileName2));


            int file1ReadIndex = 0;
            int file2ReadIndex = 0;

            int file1LastWordIndex = 0;
            int file2LastWordIndex = 0;

            bool file1Finished = false;
            bool file2Finished = false;

            // true to copy from file1
            // false to copy from file2
            bool readToggle = true;

            while (true)
            {

                if (file1Finished)
                {
                    output += file2.Substring(file2LastWordIndex);
                    file2Finished = true;
                }
                if (file2Finished)
                {
                    output += file1.Substring(file1LastWordIndex);
                    file1Finished = true;
                }


                if (file1Finished && file2Finished)
                {
                    break;
                }


                if (readToggle == true && file1Finished == false)
                {
                    while (file1ReadIndex < file1.Length)
                    {


                        if (delimiters.Contains(file1[file1ReadIndex]))
                        {


                            string word = file1.Substring(file1LastWordIndex, file1ReadIndex-file1LastWordIndex);

                            if (word.Length <= 0)
                            {
                                file1LastWordIndex++;
                                file1ReadIndex++;
                            }

                            string strippedWord = word;

                            if (strippedWord.Length > 0 && delimiters.Contains(word[0]))
                            {
                                strippedWord = word.Substring(1);
                            }

                            strippedWord = strippedWord.Replace("\n", "").Replace("\r", "");

                            string firstUncopiedWord = findFirstUncopiedWord(file2, file2ReadIndex, delimiters);

                            if (strippedWord == firstUncopiedWord && file2Finished == false){
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
                        }
                        file1ReadIndex++;
                    }

                    file1Finished = true;
                    readToggle = false;


                }
                else if (readToggle == false && file2Finished == false)
                {
                    while (file2ReadIndex < file2.Length)
                    {

                        if (delimiters.Contains(file2[file2ReadIndex]))
                        {

                            string word = file2.Substring(file2LastWordIndex, file2ReadIndex-file2LastWordIndex);

                            if (word.Length <= 0)
                            {
                                file2LastWordIndex++;
                                file2ReadIndex++;
                            }


                            string strippedWord = word;

                            if (strippedWord.Length > 0 && delimiters.Contains(word[0]))
                            {
                                strippedWord = word.Substring(1);
                            }

                            strippedWord = strippedWord.Replace("\n", "").Replace("\r", "");

                            string firstUncopiedWord = findFirstUncopiedWord(file1, file1ReadIndex, delimiters);


                            if (strippedWord == firstUncopiedWord && file1Finished == false){
                                if (word.Length > 0 && delimiters.Contains(word[0]))
                                {
                                    output += word[0];
                                }

                                readToggle = !readToggle;
                                file2LastWordIndex = file2ReadIndex;
                                break;
                            }

                            output += word;
                            file2LastWordIndex = file2ReadIndex;
                        }
                        file2ReadIndex++;
                    }

                    file2Finished = true;
                    readToggle = true;
                }
            }

            return output;

        }

        public static string findFirstUncopiedWord(string file, int readIndex, List<Char> delimiters)
        {
            string output = "";

            int lastWordIndex = readIndex;

            if (delimiters.Contains(file[readIndex])){
                readIndex++;
            }

            while (readIndex < file.Length)
            {

                if (delimiters.Contains(file[readIndex]))
                {
                    string word = file.Substring(lastWordIndex, readIndex-lastWordIndex);

                    word = word.Trim();
                    word = word.Replace("\n", "").Replace("\r", "");


                    if (word.Length > 0 && delimiters.Contains(word[0]))
                    {
                        word = word.Substring(1);
                    }

                    return word;
                }

                readIndex++;

            }

            return output;

        }


    }
}
