namespace ConcurrencyDemo.Examples;

public static class ThreadExample
{
    public static void Run()
    {
        var thread = new Thread(() =>
        {
            Console.WriteLine("Thread Example Running..."); 
            Thread.Sleep(1000); 
            Console.WriteLine("Thread Example Completed.");
        }); 
        
        thread.Start();
        thread.Join();
    }
}