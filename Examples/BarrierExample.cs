namespace ConcurrencyDemo.Examples;

public static class BarrierExample
{
    private static readonly Barrier _barrier = new Barrier(3, b => 
        Console.WriteLine($"Phase {b.CurrentPhaseNumber} completed.")); 
    
    public static void Run() 
    {
        for (var i = 0; i < 3; i++)
        {
            var i1 = i;
            Task.Run(() => DoWork(i1));
        }

        // Give time for tasks to complete before the main thread ends
        Task.Delay(3000).Wait(); 
        Console.WriteLine("Barrier Example Completed.");
        
    }

    private static void DoWork(int taskNumber)
    {
        Console.WriteLine($"Task {taskNumber} is starting phase 1."); 
        Task.Delay(1000).Wait(); 
        _barrier.SignalAndWait(); 
        
        Console.WriteLine($"Task {taskNumber} is starting phase 2."); 
        Task.Delay(1000).Wait(); 
        _barrier.SignalAndWait();
    }
}