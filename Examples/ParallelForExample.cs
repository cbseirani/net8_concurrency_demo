namespace ConcurrencyDemo.Examples;

public static class ParallelForExample
{
    public static void Run()
    {
        Console.WriteLine("Parallel.For Example Running..."); 
        
        Parallel.For(0, 10, i => {
            Console.WriteLine($"Parallel.For Iteration {i}"); 
            Task.Delay(100).Wait();
        }); 
        
        Console.WriteLine("Parallel.For Example Completed.");
    }
}