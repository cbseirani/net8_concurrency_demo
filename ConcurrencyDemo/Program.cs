
using ConcurrencyDemo.Examples;

Console.WriteLine("Concurrency Examples:"); 

// Task Example
TaskExample.Run(); 

// Async/Await Example
await AsyncAwaitExample.Run(); 

// Thread Example
ThreadExample.Run(); 

// Parallel.For Example
ParallelForExample.Run(); 

// PLINQ Example
PLINQExample.Run(); 

// Concurrent Collections Example
ConcurrentCollectionsExample.Run(); 

// Locks Example
LocksExample.Run(); 

// ThreadPool Example
ThreadPoolExample.Run();

// Semaphore Example
SemaphoreExample.Run();

// CancellationToken Example
CancellationTokenExample.Run();

// Barrier Example
BarrierExample.Run();

// ManualResetEvent Example
ManualResetEventExample.Run();

// Asynchronous Streams Example
await AsyncStreamExample.Run();

// ReaderWriterLockSlim Example
ReaderWriterLockSlimExample.Run();

// Producer-Consumer Example
ProducerConsumerExample.Run();

// Task Progress Example
await TaskProgressExample.Run();

// Reactive Extensions Example
ReactiveExtensionsExample.Run();

// Channel Example
ChannelExample.Run();

// Concurrent Dictionary Example
ConcurrentDictionaryExample.Run();

Console.WriteLine("Thanks!"); 