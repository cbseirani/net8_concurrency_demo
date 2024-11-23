using System.Collections.Concurrent;

namespace ConcurrencyDemo.Examples;

public static class ConcurrentCollectionsExample
{
    public static void Run()
    {
        var concurrentDictionary = new ConcurrentDictionary<int, int>(); 
        
        Console.WriteLine("Concurrent Collections Example Running..."); 
        
        Parallel.For(0, 10, i => {
            concurrentDictionary.TryAdd(i, i * i);
        });

        foreach (var kvp in concurrentDictionary)
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        
        Console.WriteLine("Concurrent Collections Example Completed.");
    }
}