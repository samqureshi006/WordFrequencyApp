using System.Linq;
using WordFrequencyApp.Application.Interfaces;

namespace WordFrequencyApp.Infrastructure.FileProcessing
{
    public sealed class WordCounter : IWordCounter
    {
        #region Public Methods

        /// <summary>
        /// CountWords
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public Dictionary<string, int> CountWords(IEnumerable<string> words)
        {
            var counts = new Dictionary<string, int>(StringComparer.Ordinal);
            foreach (var word in words)
            {
                if (counts.TryGetValue(word, out var count))
                {
                    counts[word] = count + 1;
                }
                else
                {
                    counts[word] = 1;
                }
            }
            return counts;
        }
        #endregion
    }
}
