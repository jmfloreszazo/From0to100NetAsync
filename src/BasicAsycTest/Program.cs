Console.WriteLine("Start process...");
await DoProcessAsync();
Console.WriteLine("Continue process...");
await DoBlockingOneProcessAsync();
Console.WriteLine("Continue process...");
await DoBlockingTwoProcessAsync();
Console.WriteLine("End process...");

async Task DoProcessAsync()
{
    Console.WriteLine($"Doing process in {nameof(DoProcessAsync)}");
    await DoFirstProcessAsync();
    await DoSecondProcessAsync();
    Console.WriteLine($"Did process in {nameof(DoProcessAsync)}");
}

async Task DoBlockingOneProcessAsync()
{
    Console.WriteLine($"Doing process in {nameof(DoBlockingOneProcessAsync)}");
    await DoFirstProcessAsync();
    await DoSecondProcessAsync();
    Console.WriteLine($"Did process in {nameof(DoBlockingOneProcessAsync)}");
}

async Task DoBlockingTwoProcessAsync()
{
    Console.WriteLine($"Doing process in {nameof(DoBlockingTwoProcessAsync)}");
    await DoFirstProcessAsync();
    await DoSecondProcessAsync();
    Console.WriteLine($"Did process in {nameof(DoBlockingTwoProcessAsync)}");
}

async Task DoFirstProcessAsync()
{
    Console.WriteLine($"Doing process in {nameof(DoFirstProcessAsync)}");
    await DoThirdProcessAsync();
    Console.WriteLine($"Did process in {nameof(DoFirstProcessAsync)}");
}

async Task DoSecondProcessAsync()
{
    Console.WriteLine($"Doing process in {nameof(DoSecondProcessAsync)}");
    await Task.Delay(500);
    Console.WriteLine($"Did process in {nameof(DoSecondProcessAsync)}");
}

async Task DoThirdProcessAsync()
{
    Console.WriteLine($"Doing process in {nameof(DoThirdProcessAsync)}");
    await Task.Delay(1500);
    Console.WriteLine($"Did process in {nameof(DoThirdProcessAsync)}");
}