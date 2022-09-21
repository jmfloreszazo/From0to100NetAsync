using BenchmarkDotNet.Attributes;

namespace asyncelidingtest;

public class BenchmarksEleding
{
    Service service = new ();
    ServiceAsync serviceAsync = new ();

    [Benchmark]
    public async Task WithoutAsync()
    {
        var data = await service.GetDataAsync();
       
    }

    [Benchmark]
    public async Task WithAsync()
    {
        var dataAsync = await serviceAsync.GetDataAsync();
    }

}