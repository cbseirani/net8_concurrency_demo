using System.Threading.Channels;

namespace ConcurrencyDemo.Examples;

public static class ChannelExample
{
    public static void Run()
    {
        var channel = Channel.CreateUnbounded<int>();

        var producer = Task.Run(async () => await ProduceAsync(channel.Writer));
        var consumer = Task.Run(async () => await ConsumeAsync(channel.Reader));

        Task.WaitAll(producer, consumer);
        Console.WriteLine("Channel Example Completed.");
    }

    private static async Task ProduceAsync(ChannelWriter<int> writer)
    {
        for (var i = 0; i < 20; i++)
        {
            await writer.WriteAsync(i);
            Console.WriteLine($"Produced: {i}");
            await Task.Delay(100);
        }
        writer.Complete();
    }

    private static async Task ConsumeAsync(ChannelReader<int> reader)
    {
        await foreach (var item in reader.ReadAllAsync())
        {
            Console.WriteLine($"Consumed: {item}");
            await Task.Delay(200);
        }
    }
}