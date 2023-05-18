using System.Collections.Generic;

namespace TextAnalyzer.Interfaces
{
    public interface ITextAnalyzer
    {
        List<string> ParsedWords { get; }
        IWordAnalyzer Analyzer { get; }

        List<AnalyzeResults> TextAnalyze(string[] words);

        void AddResult(AnalyzeResults results);
    }
}
