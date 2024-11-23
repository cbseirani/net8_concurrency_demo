using System.Reactive.Linq;

namespace ConcurrencyDemo.Examples;

public static class ReactiveExtensionsExample
{
    public static void Run()
    {
        var observable = Observable
            .Interval(TimeSpan.FromMilliseconds(500))
            .Take(10);

        var subscription = observable.Subscribe(
            onNext: value => Console.WriteLine($"Received value: {value}"),
            onCompleted: () => Console.WriteLine("Sequence Completed")
        );

        // Give time for sequence to complete before the main thread ends
        Task.Delay(6000).Wait();
        Console.WriteLine("Reactive Extensions Example Completed.");
        subscription.Dispose();
    }
}