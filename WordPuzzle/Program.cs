using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {

            bool isValidfile = false;
            string filepath = string.Empty;
            while (!isValidfile)
            {
                if (!isValidfile)
                    Console.WriteLine("Please input a valid text file path! for ex.- C:\\wordlist.txt");
                filepath = Console.ReadLine();
                if(File.Exists(filepath) && new FileInfo(filepath).Extension == ".txt")
                    isValidfile = true;
            }

            Console.WriteLine("-------------------------------------------------------------");

            string text = File.ReadAllText(filepath, Encoding.UTF8);
            text = text.Replace("\r","");
            string[] words = text.Split('\n');

            WordUtility wordUtil = new WordUtility(words.Distinct().ToArray());

            string output = wordUtil.GetNthLongestWordOfWords(1);
            Console.WriteLine("Longest Word of words is: {0}\n", output);

            output = wordUtil.GetNthLongestWordOfWords(2);
            Console.WriteLine("2nd Longest Word of words is: {0}\n", output);

            int count = wordUtil.GetNumberOfWordOfWords();
            Console.WriteLine("Count of word of Words is: {0}\n", count);
            Console.ReadKey();
        }
    }
}
