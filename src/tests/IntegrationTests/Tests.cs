namespace Beatoven.IntegrationTests;

[TestClass]
public partial class Tests
{
    private static BeatovenClient GetAuthenticatedClient()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("BEATOVEN_API_KEY") is { Length: > 0 } apiKeyValue
                ? apiKeyValue
                : throw new AssertInconclusiveException("BEATOVEN_API_KEY environment variable is not found.");

        var client = new BeatovenClient(apiKey);
        
        return client;
    }
}
