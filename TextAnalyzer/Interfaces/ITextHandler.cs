namespace TextAnalyzer.Interfaces
{
    public interface ITextHandler
    {
        string[] GetWords(string text);

        int GetCharCount(string[] words);
    }
}
