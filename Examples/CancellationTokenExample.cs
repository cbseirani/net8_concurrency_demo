namespace ConcurrencyDemo.Examples;

public static class CancellationTokenExample
{
    public static void Run() 
    { 
        var cts = new CancellationTokenSource(); 
        var token = cts.Token; 
        var task = Task.Run(() => DoWork(token), token); 
        
        // Cancel the task after 500 milliseconds
        Task.Delay(500, token).ContinueWith(_ => cts.Cancel(), token);
        
        try
        {
            task.Wait(token);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Task was canceled.");
        } 
    }

    private static void DoWork(CancellationToken token)
    {
        for (var i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested(); 
            Console.WriteLine($"Working... {i}"); 
            Task.Delay(200, token).Wait(token);
        }
    }
}