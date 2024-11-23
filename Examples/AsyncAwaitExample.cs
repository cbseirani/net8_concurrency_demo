namespace ConcurrencyDemo.Examples;

public static class AsyncAwaitExample
{
    public static async Task Run()
    {
        Console.WriteLine("Async/Await Example Running..."); 
        await Task.Delay(1000);
        Console.WriteLine("Async/Await Example Completed.");
    }
}