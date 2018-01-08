using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzle
{
    public class WordUtility
    {
        private string[] wordList;
        public WordUtility(string[] wordList)
        {
            this.wordList = wordList;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="words"></param>
       /// <param name="n"></param>
       /// <returns></returns>
        public string GetNthLongestWordOfWords(int n)
        {
            int count = 0;
            var sortedByLengthWords = wordList.OrderByDescending(x => x.Length);
            string output = string.Empty;
            foreach(var word in sortedByLengthWords)
            {
                if (IsValidCombinationOfWords(word))
                {
                    count++;
                    if (count == n)
                    {
                        output = word;
                        break;
                    }
                }
            }
            return output;
        }

        public int GetNumberOfWordOfWords()
        {
            var sorted = wordList.OrderByDescending(x => x.Length);
            List<string> wordOfWords = new List<string>();
            foreach (var word in sorted)
            {
                if (IsValidCombinationOfWords(word))
                    wordOfWords.Add(word);
            }
            return wordOfWords.Count();
        }

        /// <summary>
        /// check if the word is constructed using other words
        /// </summary>
        /// <param name="word">input word for validating whether its a word of words</param>
        /// <returns></returns>
        public bool IsValidCombinationOfWords(string word)
        {
            int start = 0;
            List<string> shortWords = new List<string>();
            string token = string.Empty;
            while(start < word.Length)
            {
                int nextStart = start;
                token = string.Empty;
                for (int i = start; i < word.Length; i++)
                {
                    token += word[i];
                    if (wordList.Contains(token) && token != word)
                    {
                        shortWords.Add(token);
                        start = i + 1;
                    }
                }

                if (nextStart == start)
                    return false;
            }
            
            return true;
        }
    }
}
