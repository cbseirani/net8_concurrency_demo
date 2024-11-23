namespace ConcurrencyDemo.Examples;

public static class AsyncStreamExample
{
    public static async Task Run()
    {
        await foreach (var number in GenerateNumbersAsync())
            Console.WriteLine($"Received number: {number}");
    }

    private static async IAsyncEnumerable<int> GenerateNumbersAsync()
    {
        for (var i = 0; i < 10; i++)
        {
            await Task.Delay(200); 
            yield return i;
        }
    }
}