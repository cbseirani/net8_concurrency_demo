namespace ConcurrencyDemo.Examples;

public static class ThreadPoolExample
{
    public static void Run() 
    { 
        Console.WriteLine("ThreadPool Example Running..."); 
        
        ThreadPool.QueueUserWorkItem(state =>
        {
            Console.WriteLine("ThreadPool Task Running..."); 
            Thread.Sleep(1000); 
            Console.WriteLine("ThreadPool Task Completed.");
        }); 
        
        // Give time for the ThreadPool task to complete before the main thread ends
        Thread.Sleep(2000); 
        
        Console.WriteLine("ThreadPool Example Completed."); 
    }
}