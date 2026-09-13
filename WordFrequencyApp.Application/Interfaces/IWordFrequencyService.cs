using WordFrequencyApp.Domain.Entities;

namespace WordFrequencyApp.Application.Interfaces
{
    public interface IWordFrequencyService
    {
        #region Public Methods
        /// <summary>
        /// GetTopWords
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="topCount"></param>
        /// <returns></returns>
        IReadOnlyList<WordFrequency> GetTopWords(string filePath,int topCount);

        #endregion
    }
}
