using System.Collections.Generic;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer
{
    public class WordsTextAnalyzer : ITextAnalyzer
    {
        public List<string> ParsedWords { get; private set; }
        public IWordAnalyzer Analyzer { get; private set; }

        public WordsTextAnalyzer(IWordAnalyzer wordAnalyzer)
        {
            ParsedWords = new List<string>();
            Analyzer = wordAnalyzer;
        }


        public void AddResult(AnalyzeResults results)
        {
            ParsedWords.Add(results.Word);
        }

        public List<AnalyzeResults> TextAnalyze(string[] words)
        {
            List<AnalyzeResults> resultsList = new List<AnalyzeResults>();

            foreach (string word in words)
            {
                if (IsUniqueWord(word))
                {
                    var results = Analyzer.WordAnalyze(words, word);
                    resultsList.Add(results);
                }
            }

            ParsedWords.Clear();

            return resultsList;
        }

        private bool IsUniqueWord(string word)
        {
            if (ParsedWords.Contains(word))
            {
                return false;
            }

            ParsedWords.Add(word);
            return true;
        }
    }
}