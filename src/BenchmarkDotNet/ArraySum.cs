using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNetSample;

public class ArraySum
{
    private readonly int n = 100;
    private long[,]? _a;

    [GlobalSetup]
    public void Setup()
    {
        _a = new long[n, n];
    }

    [Benchmark(Baseline = true)]
    public long Sum_ij()
    {
        long sum = 0;
        for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
            sum += _a[i, j];
        return sum;
    }

    [Benchmark]
    public long Sum_ji()
    {
        long sum = 0;
        for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
            sum += _a[j, i];
        return sum;
    }
}