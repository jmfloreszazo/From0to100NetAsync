namespace AsynchronousDelegatesSample
{
    class Program
    {
        public static void Main(string[] args)
        {

            Func<string, int, string> method = DoSomeWork;

            var t1 = method.BeginInvoke("Value01", 1234, null, null);
            var t2 = method.BeginInvoke("Value01", 1234, DoSomeWorkTaskCompleted, method);

            var result = method.EndInvoke(t1);

            Console.WriteLine("Status of T1 is : " + result);

            Console.WriteLine("Main thread ends...");

            Console.ReadKey();
        }

        private static string DoSomeWork(string param1, int param2)
        {
            Console.WriteLine("Thread is background : {0}", Thread.CurrentThread.IsBackground);
            Console.WriteLine("Input parameter : {0} and {1}", param1, param2);
            return "Success";
        }

        private static void DoSomeWorkTaskCompleted(IAsyncResult asyncResult)
        {
            var target = (Func<string, int, string>) asyncResult.AsyncState;
            var result = target.EndInvoke(asyncResult);
            Console.WriteLine("Do Some Work has been completed and result is {0}", result);
        }
    }
}