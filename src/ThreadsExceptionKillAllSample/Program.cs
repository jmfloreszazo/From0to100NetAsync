var thread = new Thread(ThrowException) {IsBackground = true};
thread.Start();
Console.ReadLine();

static void ThrowException()
{
    throw new NullReferenceException();
}