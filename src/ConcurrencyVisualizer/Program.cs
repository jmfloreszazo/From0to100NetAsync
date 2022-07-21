var thread1 = new Thread(DoSomething);
var thread2 = new Thread(DoSomething);
var thread3 = new Thread(DoSomething);
var thread4 = new Thread(DoSomething);
var thread5 = new Thread(DoSomething);

Console.WriteLine("End test...");

static void DoSomething(object obj)
{
    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
    while (!cts.IsCancellationRequested)
    {

    }
}