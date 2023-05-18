namespace TextAnalyzer.Interfaces
{
    public interface IWordAnalyzer
    {
        AnalyzeResults WordAnalyze(string[] words, string keyWord);
    }
}
