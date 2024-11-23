namespace ConcurrencyDemo.Examples;

public static class TaskProgressExample
{
    public static async Task Run()
    {
        var progress = new Progress<int>(percent => Console.WriteLine($"Progress: {percent}%"));
        await LongRunningOperationAsync(progress);
        Console.WriteLine("Task Progress Example Completed.");
    }

    private static async Task LongRunningOperationAsync(IProgress<int> progress)
    {
        for (var i = 0; i <= 100; i += 10)
        {
            await Task.Delay(200); 
            // Simulate work
            progress.Report(i);
        }
    }
}