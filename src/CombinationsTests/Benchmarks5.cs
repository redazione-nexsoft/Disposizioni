using Combinations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CombinationsTests
{
    [TestClass]
    public class Benchmarks5
    {
        [TestMethod]
        public void StaticIterations()
        {
            Benchmark("StaticIterations.Combina", () => Combinations.StaticIterations.Combina4_5(new int[] { 1, 2, 3, 4 }, 5));
		}

		[TestMethod]
		public void LinearIterations()
		{
            Benchmark("LinearIterations.Combina", () => Combinations.LinearIterations.Combina(new int[] { 1, 2, 3, 4 }, 5));
		}

		[TestMethod]
		public void RecursiveIterations()
		{
			Benchmark("RecursiveIterations.Combina", () => Combinations.RecursiveIterations.Combina(new int[] { 1, 2, 3, 4 }, 5));
		}

		private static void Benchmark<T>(string name, Func<T[][]> a)
		{
			var w = new Stopwatch();
			w.Start();
			var combinazioni = a();
			w.Stop();
			long cnt = combinazioni.Length;
			double s = (double)w.Elapsed.TotalSeconds;
			var t = (int)((s > 0) ? (cnt / s) : cnt);
			System.Diagnostics.Debug.Print($"{name}: generate {cnt} in {s} s ({t} al secondo)");
		}
	}
}
