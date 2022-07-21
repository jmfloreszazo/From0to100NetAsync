const int singleWorkItemsDelayMs = 1_000; //Play with 1_000 and 60_000.

Console.Clear();

ThreadPool.GetMinThreads(out var minWorkerThreads, out var minCompletionPortThreads);
ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxCompletionPortThreads);

Console.WriteLine($"Worker threads => Min = {minWorkerThreads}, Max = {maxWorkerThreads}");
Console.WriteLine($"IOCP threads => Min = {minCompletionPortThreads}, Max = {maxCompletionPortThreads}");

var statsThreads = new Thread(PrintThreadPoolStats)
{
    IsBackground = true
};
statsThreads.Start();

var spawingThread = new Thread(SpanWork)
{
    IsBackground = true
};
spawingThread.Start();

Console.ReadLine();

static void DoWork(object? arg)
{
    Console.CursorTop = 2;
    Console.Write(".");
    Thread.Sleep(singleWorkItemsDelayMs);
}

static void SpanWork()
{
    while (true)
    {
        Thread.Sleep(100);
        ThreadPool.QueueUserWorkItem(DoWork);
    }
}

static void PrintThreadPoolStats()
{
    while (true)
    {
        Console.CursorLeft = 0;
        Console.CursorTop = 2;
        ThreadPool.GetAvailableThreads(out var workerThreads, out var completionPortThreads);
        Console.WriteLine($"Current = {ThreadPool.ThreadCount}, Queued = {ThreadPool.PendingWorkItemCount}, Done = {ThreadPool.CompletedWorkItemCount}, Worker = {workerThreads}, IOCP = {completionPortThreads}");
        Thread.Sleep(100);
    }
}