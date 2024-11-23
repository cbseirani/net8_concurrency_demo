namespace ConcurrencyDemo.Examples;

public static class LocksExample
{
    private static readonly object _lock = new object();

    public static void Run()
    {
        Console.WriteLine("Locks Example Running..."); 
        
        var counter = 0;
        Parallel.For(0, 10, i => {
            lock (_lock)
            {
                counter++; 
                Console.WriteLine($"Counter: {counter}");
            }
        });
        
        Console.WriteLine("Locks Example Completed.");
    }
}