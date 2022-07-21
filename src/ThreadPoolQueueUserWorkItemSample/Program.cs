AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException; 
ThreadPool.QueueUserWorkItem(DoSomeWork);
Console.ReadLine();

static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
{
    //Log & save your work
}

static void DoSomeWork(object? sender)
{
    throw new NullReferenceException();
}