using System;
using System.Runtime.InteropServices.JavaScript;
using System.Threading;

Console.WriteLine("Hello, Browser!");

// Multithreading

const int minSleepPeriod = 100; // ms
const int maxSleepPeriod = 3000; // ms

// Run multiple threads in .NET app running in a browser (using WASM).
new Thread(SecondThread).Start();
MainThread();

static void MainThread()
{
    Console.WriteLine($"Main thread: ManagedThreadId =  {Thread.CurrentThread.ManagedThreadId}");

    for (int i = 0; i < 10; ++i)
    {
        Console.WriteLine($"Main thread: step {i}");
        Thread.Sleep(Random.Shared.Next(minSleepPeriod, maxSleepPeriod));
    }
}

static void SecondThread()
{
    Console.WriteLine($"Second thread: ManagedThreadId = {Thread.CurrentThread.ManagedThreadId}");

    for (int i = 0; i < 10; ++i)
    {
        Console.WriteLine($"Second thread: step {i}");
        Thread.Sleep(Random.Shared.Next(minSleepPeriod, maxSleepPeriod));
    }
}


public partial class MyClass
{
    [JSExport]
    internal static string Greeting()
    {
        var text = $"Hello, World! Greetings from {GetHRef()}";
        Console.WriteLine(text);
        return text;
    }

    [JSImport("window.location.href", "main.js")]
    internal static partial string GetHRef();
}
