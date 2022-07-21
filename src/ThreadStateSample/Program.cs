Thread newThread =
    new Thread(new ThreadStart(ThreadMethod));

Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
newThread.Start();

Thread.Sleep(300);
Console.WriteLine("ThreadState: {0}", newThread.ThreadState);

Thread.Sleep(1000);
Console.WriteLine("ThreadState: {0}", newThread.ThreadState);

static void ThreadMethod()
{
    Thread.Sleep(1000);
}