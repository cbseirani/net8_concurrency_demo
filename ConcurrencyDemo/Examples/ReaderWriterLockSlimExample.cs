namespace ConcurrencyDemo.Examples;

public static class ReaderWriterLockSlimExample
{
    private static readonly ReaderWriterLockSlim _lock = new ();
    private static int _resource;

    public static void Run()
    {
        var tasks = new[]
        {
            Task.Run(ReadResource), Task.Run(ReadResource), Task.Run(WriteResource)
        }; 
        
        Task.WaitAll(tasks); 
        Console.WriteLine("ReaderWriterLockSlim Example Completed.");
    }

    private static void ReadResource()
    {
        _lock.EnterReadLock();
        try
        {
            Console.WriteLine($"Read resource: {_resource}");
            Task.Delay(500).Wait();
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    private static void WriteResource()
    {
        _lock.EnterWriteLock();
        try
        {
            _resource++;
            Console.WriteLine($"Wrote resource: {_resource}");
            Task.Delay(500).Wait();
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
}