AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
var thread = new Thread(ThrowException) {IsBackground = true};
thread.Start();
Console.ReadLine();

static void ThrowException()
{
    throw new NullReferenceException();
}

static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
{
    //Log & Save the work
}