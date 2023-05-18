using Microsoft.Extensions.DependencyInjection;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ITextAnalyzer, WordsTextAnalyzer>();
            services.AddTransient<ITextHandler, TextHandler>();
            services.AddTransient<IWordAnalyzer, WordAnalyzer>();

            return services;
        }
    }
}
