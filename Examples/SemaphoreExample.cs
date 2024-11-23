namespace ConcurrencyDemo.Examples;

public static class SemaphoreExample
{
    private static readonly SemaphoreSlim _semaphore = new (2); 
    
    // Allows 2 threads to enter the semaphore at once.
    public static void Run() 
    { 
        Console.WriteLine("Semaphore Example Running..."); 
        
        for (var i = 0; i < 5; i++) 
        { 
            var taskNumber = i; 
            
            // To avoid closure issues.
            Task.Run(() => AccessResource(taskNumber));
        } 
        
        
        // Give time for tasks to complete before the main thread ends
        Task.Delay(3000).Wait(); 
        Console.WriteLine("Semaphore Example Completed.");
        
    } 
    
    private static void AccessResource(int taskNumber) 
    { 
        Console.WriteLine($"Task {taskNumber} waiting to enter semaphore."); 
        _semaphore.Wait();

        try
        {
            Console.WriteLine($"Task {taskNumber} has entered the semaphore.");
            
            // Simulate work
            Task.Delay(1000).Wait();
            Console.WriteLine($"Task {taskNumber} is leaving the semaphore.");
        }
        finally
        {
            _semaphore.Release();
        }
    }
}