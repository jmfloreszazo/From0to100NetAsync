using BenchmarkDotNet.Attributes;

namespace Benchmark;

public class ValueTaskBenchamrk
{
    readonly Repository _repo = new Repository();

    [Benchmark]
    public async Task RunTaskAsync() => await _repo.GetDataWithTaskAsync("test");


    [Benchmark]
    public async Task RunValueTaskAsync() => await _repo.GetDataWithValueTaskAsync("test");
}