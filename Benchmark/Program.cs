using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ShisokuEnzan;

namespace Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }

        [Benchmark]
        public void ShisokuEnzanBenchmark()
        {
            Enzan.Calc("100000 * 100000");
        }

        [Benchmark]
        public int IntBenchmark()
        {
            return 100 * 100;
        }
    }
}
