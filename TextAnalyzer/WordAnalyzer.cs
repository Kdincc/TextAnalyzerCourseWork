using System;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer
{
    public class WordAnalyzer : IWordAnalyzer
    {
        public AnalyzeResults WordAnalyze(string[] words, string keyWord)
        {
            string lowerKeyWord = keyWord.ToLower();
            int matches = 0;

            foreach (string word in words)
            {
                if (word.Equals(lowerKeyWord))
                {
                    matches++;
                }
            }

            double percentage = Math.Round((double)matches / words.Length * 100, 3);

            return new AnalyzeResults(lowerKeyWord, percentage, matches);
        }
    }
}
