using WordFrequencyApp.Application.Interfaces;
using WordFrequencyApp.Domain.Entities;

namespace WordFrequencyApp.Application.Services
{
    public sealed class WordFrequencyService : IWordFrequencyService
    {
        #region Private Fields

        private readonly IWordReader _wordReader;
        private readonly IWordCounter _wordCounter;

        #endregion

        #region Constructor

        /// <summary>
        /// WordFrequencyService
        /// </summary>
        /// <param name="wordReader"></param>
        /// <param name="wordCounter"></param>
        public WordFrequencyService(IWordReader wordReader,IWordCounter wordCounter)
        {
            _wordReader = wordReader;
            _wordCounter = wordCounter;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// GetTopWords
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="topCount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IReadOnlyList<WordFrequency> GetTopWords(string filePath,int topCount)
        {
            // Validate that the file exists
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path is required.",nameof(filePath));
            }
            // Validate count is greater than 0
            if (topCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(topCount));
            }
            var words = _wordReader.ReadWords(filePath);
            var counts = _wordCounter.CountWords(words);
            return counts
                .Select(x => new WordFrequency(x.Key, x.Value))
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Word, StringComparer.Ordinal)
                .Take(topCount)
                .ToList();
        }

        #endregion
    }
}
