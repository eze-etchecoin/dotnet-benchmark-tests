using BenchmarkDotNet.Attributes;
using DotnetBenchmarkTests.TestClasses;

namespace DotnetBenchmarkTests.BenchmarkClasses;
public class CollectionCreationBenchmarks
{
    [Params(10, 100, 1000)]
    public int N { get; set; }
    
    [Benchmark]
    public void CreateWithForeach()
    {
        var people = new List<Person>();
        for (var i = 0; i < N; i++)
        {
            people.Add(new Person());
        }
    }

    [Benchmark]
    public void CreateWithLinq()
    {
        var people = Enumerable
            .Range(0, N)
            .Select(_ => new Person())
            .ToList();
    }
}
