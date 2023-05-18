using System;
using System.Linq;
using System.Text.RegularExpressions;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer
{
    public class TextHandler : ITextHandler
    {
        private readonly Regex enWords = new Regex(@"\b[a-zA-Z]+\b");
        private readonly Regex uaWords = new Regex(@"\b[А-ЩЬЮЯЄІЇҐа-щьюяєіїґ']+\b");

        public string[] GetWords(string text)
        {
            string[] words = text.ToLower().Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            words = words.Where(x => enWords.IsMatch(x) || uaWords.IsMatch(x)).Select(x => x.Trim(new char[] { ',', '.', '!', '?', ':', ';' })).ToArray();

            return words;
        }

        public int GetCharCount(string[] words)
        {
            int charSum = 0;

            foreach (string word in words)
            {
                charSum += word.Length;
            }

            return charSum;
        }
    }
}
