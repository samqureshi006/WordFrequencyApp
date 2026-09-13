using System.Text;
using WordFrequencyApp.Application.Interfaces;

namespace WordFrequencyApp.Infrastructure.FileProcessing
{
    public sealed class FileWordReader : IWordReader
    {
        #region Private Fields

        private const int BufferSize = 64 * 1024;

        #endregion

        #region Public Methods
        public IEnumerable<string> ReadWords(string filePath)
        {
            using var stream = new FileStream(filePath,FileMode.Open,FileAccess.Read,FileShare.Read,BufferSize,FileOptions.SequentialScan);
            var buffer = new byte[BufferSize];
            var currentWord = new StringBuilder();
            int bytesRead;
            while ((bytesRead = stream.Read(buffer,0,buffer.Length)) > 0)
            {
                for (int i = 0; i < bytesRead; i++)
                {
                    byte value = buffer[i];

                    if (IsAsciiLetter(value))
                    {
                        currentWord.Append((char)ToLowerAscii(value));
                    }
                    else if (currentWord.Length > 0)
                    {
                        yield return currentWord.ToString();
                        currentWord.Clear();
                    }
                }
            }

            if (currentWord.Length > 0)
            {
                yield return currentWord.ToString();
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// IsAsciiLetter
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsAsciiLetter(byte value)
        {
            return value is >= (byte)'A' and <= (byte)'Z' or >= (byte)'a' and <= (byte)'z';
        }

        /// <summary>
        /// ToLowerAscii
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static byte ToLowerAscii(byte value)
        {
            if (value >= (byte)'A' && value <= (byte)'Z')
            {
                return (byte)(value + ('a' - 'A'));
            }

            return value;
        }

        #endregion
    }
}
