using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequencyApp.Application.Interfaces
{
    public interface IWordReader
    {
        #region Public Methods
        /// <summary>
        /// ReadWords - It reads the words from the file and returns a collection.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IEnumerable<string> ReadWords(string filePath);
        #endregion
    }
}
