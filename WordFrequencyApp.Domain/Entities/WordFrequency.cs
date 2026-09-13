namespace WordFrequencyApp.Domain.Entities
{
    /// <summary>
    /// WordFrequency
    /// </summary>
    /// <param name="Word"></param>
    /// <param name="Count"></param>
    public sealed record WordFrequency(
     string Word,
     int Count);
}
