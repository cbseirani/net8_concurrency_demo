namespace ConcurrencyDemo.Examples;

public static class TaskExample
{
    public static void Run()
    {
        Task.Run(() => {
            Console.WriteLine("Task Example Running...");
            Task.Delay(1000).Wait();
            Console.WriteLine("Task Example Completed.");
        }).Wait();
    }
}