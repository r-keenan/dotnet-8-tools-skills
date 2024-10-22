namespace DesignPatternsApp
{
    // Adapter pattern
    public interface ITextProcessor
    {
        void ProcessText(string text);
    }

    public class TextProcessor : ITextProcessor
    {
        public void ProcessText(string text)
        {
            WriteLine($"Processing text: {text}");
        }
    }

    public interface IAdvancedTextAnalytics
    {
        void AnalyzeTextComplexity(string text);
        void FindKeyPhrases(string text);
    }

    public class AdvancedTextAnalytics : IAdvancedTextAnalytics
    {
        public void AnalyzeTextComplexity(string text)
        {
            WriteLine($"Analyzing text complexity: {text}");
        }

        public void FindKeyPhrases(string text)
        {
            WriteLine($"Finding key phrases in ${text}");
        }
    }

    // Define the adapter
    public class TextAnalyticsAdapter : ITextProcessor
    {
        private readonly IAdvancedTextAnalytics _advancedTextAnalytics;

        public TextAnalyticsAdapter(IAdvancedTextAnalytics advancedTextAnalytics)
        {
            _advancedTextAnalytics = advancedTextAnalytics;
        }

        public void ProcessText(string text)
        {
            _advancedTextAnalytics.AnalyzeTextComplexity(text);
            _advancedTextAnalytics.FindKeyPhrases(text);
        }
    }
}
