namespace ConcurrencyDemo.Examples;

public static class ManualResetEventExample
{
    private static readonly ManualResetEvent _manualResetEvent = new (false);

    public static void Run()
    {
        Task.Run(WaitForSignal); 
        Console.WriteLine("Press Enter to signal..."); 
        Console.ReadLine(); 
        _manualResetEvent.Set();
    }

    private static void WaitForSignal()
    {
        Console.WriteLine("Waiting for signal..."); 
        _manualResetEvent.WaitOne(); 
        Console.WriteLine("Signal received.");
    }
}