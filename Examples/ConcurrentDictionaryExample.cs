using System.Collections.Concurrent;

namespace ConcurrencyDemo.Examples;

public static class ConcurrentDictionaryExample
{
    private static readonly ConcurrentDictionary<string, int> _concurrentDictionary = new ();

    public static void Run()
    {
        var tasks = new Task[3];

        tasks[0] = Task.Run(() => AddOrUpdate("A", 1));
        tasks[1] = Task.Run(() => AddOrUpdate("B", 2));
        tasks[2] = Task.Run(() => AddOrUpdate("A", 3));

        Task.WaitAll(tasks);

        foreach (var kvp in _concurrentDictionary)
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");

        Console.WriteLine("Concurrent Dictionary Example Completed.");
    }

    private static void AddOrUpdate(string key, int value)
    {
        _concurrentDictionary.AddOrUpdate(key, value, (k, v) => v + value);
        Console.WriteLine($"Added/Updated: {key} = {value}");
    }
}