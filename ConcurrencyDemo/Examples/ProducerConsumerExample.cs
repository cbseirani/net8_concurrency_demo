using System.Collections.Concurrent;

namespace ConcurrencyDemo.Examples;

public static class ProducerConsumerExample
{ 
    private static readonly BlockingCollection<int> _blockingCollection = new (boundedCapacity: 10);

    public static void Run()
    {
        var producerTask = Task.Run(Producer); 
        var consumerTask = Task.Run(Consumer); 
        Task.WaitAll(producerTask, consumerTask); 
        Console.WriteLine("Producer-Consumer Example Completed.");
    }

    private static void Producer()
    {
        for (var i = 0; i < 20; i++)
        {
            _blockingCollection.Add(i); 
            Console.WriteLine($"Produced: {i}"); 
            Task.Delay(100).Wait();
        } 
        
        _blockingCollection.CompleteAdding();
    }

    private static void Consumer()
    {
        foreach (var item in _blockingCollection.GetConsumingEnumerable())
        {
            Console.WriteLine($"Consumed: {item}");
            Task.Delay(200).Wait();
        }
    }
}