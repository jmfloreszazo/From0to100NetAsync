//SleepAsyncOne(); //Case 1.A
//_ = SleepAsyncOne(); //Case 2.B
//await SleepAsyncOne(); //Case 2.C

//SleepAsynTwo(); //Case 2.A
//_ = SleepAsynTwo(); //Case 2.B
await SleepAsynTwo(); //Case 2.C

static async Task SleepAsyncOne()
{
    await Task.Delay(100);
    throw new NullReferenceException();
}

static async Task<Task> SleepAsynTwo()
{
    await Task.Delay(100);
    return Task.FromException(new NullReferenceException());
}