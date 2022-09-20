using System.Diagnostics;

for (var i = 0; i < 10; i++)
{
    MethodWithThread();
    MethodWithThreadPool();
}

var stopwatch = new Stopwatch();
Console.WriteLine("Execution using Thread");
stopwatch.Start();
MethodWithThread();
stopwatch.Stop();
Console.WriteLine("Time consumed by MethodWithThread is : " +
                  stopwatch.ElapsedTicks);

stopwatch.Reset();
Console.WriteLine("Execution using Thread Pool");
stopwatch.Start();
MethodWithThreadPool();
stopwatch.Stop();
Console.WriteLine("Time consumed by MethodWithThreadPool is : " +
                  stopwatch.ElapsedTicks);

Console.Read();

void MethodWithThread()
{
    for (var i = 0; i < 10; i++)
    {
        var thread = new Thread(TestObject);
    }
}

void MethodWithThreadPool()
{
    for (var i = 0; i < 10; i++) ThreadPool.QueueUserWorkItem(TestObject);
}

void TestObject(object obj)
{
}