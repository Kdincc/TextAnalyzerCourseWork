namespace TextAnalyzer
{
    public class AnalyzeResults
    {
        public string Word { get; private set; }
        public int Matches { get; private set; } = 0;
        public double Persentage { get; private set; } = 0;

        public AnalyzeResults(string word, double persentage, int matches)
        {
            Word = word;
            Persentage = persentage;
            Matches = matches;
        }
    }
}