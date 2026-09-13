using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequencyApp.Application.Interfaces
{
    public interface IWordCounter
    {
        #region Public Methods

        /// <summary>
        /// CountWords - It Counts the frequency of word in the collection.
        /// </summary>
        /// <param name="words"></param>
        /// <returns>Dictionary object</returns>
        Dictionary<string, int> CountWords(IEnumerable<string> words);
        #endregion
    }
}
