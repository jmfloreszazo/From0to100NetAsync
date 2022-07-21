using ParallelStacksTasks;

var taskArray = new Task[10];
for (var i = 0; i < taskArray.Length; i++)
    taskArray[i] = Task.Factory.StartNew(obj =>
    {
        var data = obj as ThreadData;
        if (data == null) return;

        data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
    }, new ThreadData {Name = i, CreationTime = DateTime.Now.Ticks});
Task.WaitAll(taskArray);
foreach (var task in taskArray)
    if (task.AsyncState is ThreadData data)
        Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.", data.Name, data.CreationTime,
            data.ThreadNum);