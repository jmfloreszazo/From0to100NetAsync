using BenchmarkDotNet.Attributes;

namespace ParallelSample;

public class Benchmarks
{
    private readonly short[] _integers = new short[short.MaxValue];

    [GlobalSetup]
    public void GlobalSetup()
    {
        for (short x = 1; x <= _integers.Length - 1; x++) _integers[x] = x;
    }

    [Benchmark]
    public void StandardForEachLoopExample()
    {
        foreach (int x in _integers) Console.WriteLine($"Item {x}: {x}");
    }

    [Benchmark]
    public void ParallelForEachLoopExample()
    {
        Parallel.ForEach(_integers, x => { Console.WriteLine($"Item {x}: {x}"); });
    }

}