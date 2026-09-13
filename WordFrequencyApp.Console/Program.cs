using WordFrequencyApp.Application.Services;
using WordFrequencyApp.Infrastructure.FileProcessing;

internal class Program
{
    /// <summary>
    /// Main - Entry point of the application. It takes a file path as an argument, reads the words from the file, 
    /// counts their frequencies, and displays the top 20 most frequent words along with their counts.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.Error.WriteLine(
                "Usage: WordFrequencyApp <file-path>");

            return 1;
        }

        var filePath = args[0];

        try
        {
            var reader = new FileWordReader();
            var counter = new WordCounter();

            var service = new WordFrequencyService(
                reader,
                counter);

            var results = service.GetTopWords(
                filePath,
                20);

            foreach (var result in results)
            {
                Console.WriteLine(
                    $"{result.Count} {result.Word}");
            }

            return 0;
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine(
                $"File not found: {filePath}");

            return 1;
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine(
                "Directory was not found.");

            return 1;
        }
        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine(
                "Access denied.");

            return 1;
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine(
                $"File I/O error: {ex.Message}");

            return 1;
        }
    }
}
