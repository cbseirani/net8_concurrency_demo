namespace ConcurrencyDemo.Examples;

public static class PLINQExample
{
    public static void Run()
    {
        Console.WriteLine("PLINQ Example Running...");
        var numbers = Enumerable.Range(0, 10);

        var parallelResult = numbers.AsParallel().Select(n =>
        {
            Console.WriteLine($"Processing number {n}");
            return n * n;
        }).ToArray();

        Console.WriteLine("PLINQ Example Completed.");
    }
}