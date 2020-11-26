using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace K2
{
    class Program
    {
        static void Main(string[] args)
        {
            string InputFile = "Tekstas.txt";
            string OutputFile = "RedTekstas.txt";

            TaskUtils.PerformTasksF(InputFile, OutputFile);
        }
    }

    class TaskUtils
    {
        public static bool LowercaseLettersOnly(string line)
        {
            if (line.ToLower() == line)
            {
                return true;
            }
            return false;
        }

        public static int NumberOfDigits(string line)
        {
            int output = 0;
            foreach (char c in line)
            {
                if (Char.IsDigit(c))
                {
                    output++;
                }
            }
            return output;
        }

        public static string FindWord1InLine(string line, string punctuation)
        {

            char[] seperators = punctuation.ToCharArray();

            List<String> words = new List<String>(line.Split(seperators));

            int count = 0;

            for(int i = 0; i < words.Count; i++)
            {
                if (TaskUtils.LowercaseLettersOnly(words[i]))
                {
                    count++;
                    if (count == 1)
                    {
                        return words[i];
                    }
                }
            }

            return "";
        }

        public static string FindWord2InLine(string line, string punctuation)
        {

            char[] seperators = punctuation.ToCharArray();

            List<String> words = new List<String>(SplitWithDelimiters(line, seperators));

            List<String> highNumCountWords = new List<String>();


            foreach (String word in words)
            {

                if (NumberOfDigits(word) >= (word.Length-1)/2)
                {
                    highNumCountWords.Add(word);
                }
            }

            highNumCountWords.Sort((String a, String b) => b.Length.CompareTo(a.Length));

            if (highNumCountWords.Count > 0)
            {
                return highNumCountWords[0];
            }
            return "";
        }

        public static List<String> SplitWithDelimiters (string input, char[] delimiters)
        {
            List<String> output = new List<String>();

            List<Char> delimList = new List<Char>(delimiters);

            int lastSplitIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (delimList.Contains(input[i]))
                {
                    output.Add(input.Substring(lastSplitIndex, i-lastSplitIndex+1));
                    lastSplitIndex = i+1;
                    if (i > input.Length)
                    {
                        break;
                    }
                }
            }

            output.Add(input.Substring(lastSplitIndex, input.Length-lastSplitIndex));

            return output;
        }

        public static string EditLine (string line, string punctuation, string word)
        {

            char[] seperators = punctuation.ToCharArray();


            List<String> words = new List<String>(SplitWithDelimiters(line, seperators));

            for (int i = words.Count-1; i >= 0; i--)
            {
                if (words[i] == word)
                {
                    //words[i-1] = words[i-1].Substring(0, words[i-1].Length-1);
                    words.RemoveAt(i);
                    break;
                }
            }

            string NewLine = String.Join("", words);

            return NewLine;
        }

        /// <summary>
        /// main solving method
        /// </summary>
        /// <param name="fd">input filename</param>
        /// <param name="fr">output filenamed</param>
        public static void PerformTasksF(string fd, string fr)
        {
            List<String> InputList = new List<String>(File.ReadAllLines(fd));

            int WholeFileNumCount = 0;

            List<String> lowerCaseWordList = new List<String>();

            
            string delimiterString = InputList[0];
            InputList.RemoveAt(0);

            List<String> OutputList = new List<String>();

            foreach (String line in InputList)
            {

                WholeFileNumCount += NumberOfDigits(line);
                lowerCaseWordList.Add(FindWord1InLine(line, delimiterString));

                /*
                List<String> words = new List<String>(line.Split(delimiters));

                List<String> highNumCountWords = new List<String>();

                foreach (String word in words)
                {
                    if (NumberOfDigits(word) >= word.Length-1)
                    {
                        highNumCountWords.Add(word);
                    }
                }

                highNumCountWords.Sort((String a, String b) => b.Length.CompareTo(a.Length));

                string longestHighNumWord = highNumCountWords[0];
                */

                string wordToRemove = FindWord2InLine(line, delimiterString);
                OutputList.Add(EditLine(line, delimiterString, wordToRemove));
            }

            TextWriter tw = new StreamWriter(fr);
            tw.WriteLine("Pradinė informacija");
            tw.WriteLine(delimiterString);
            foreach (string s in InputList)
            {
                tw.WriteLine(s);
            }

            tw.WriteLine("---------------------------------");

            tw.WriteLine("Programos išvestis:");
            foreach (string s in OutputList)
            {
                tw.WriteLine(s);
            }
            tw.WriteLine("---------------------------------");
            tw.WriteLine(String.Format("Bendras skaitmenų kiekis: {0}", WholeFileNumCount));
            tw.WriteLine("Rasti eilučių žodžiai:");
            foreach (string s in lowerCaseWordList)
            {
                tw.WriteLine(s);
            }


            tw.Flush();
            tw.Close();


            return;
        }
    }
}
