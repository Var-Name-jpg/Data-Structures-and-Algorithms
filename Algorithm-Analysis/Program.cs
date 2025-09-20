using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortingBenchmark {
	public class Program {
		public static void Main(String[] args) {
			Random rand = new Random();

			// Diagnostic for generating numbers (for control)
			Stopwatch generationStopwatch = Stopwatch.StartNew();

			// 1k lists
			List<int> Sorted_1000 = new List<int>();
			List<int> Random_1000 = new List<int>();

			// 100k lists
			List<int> Sorted_100_000 = new List<int>();
			List<int> Random_100_000 = new List<int>();

			// Sorted lists
			for (int i = 1; i <= 1_000; i++) { Sorted_1000.Add(i); }
			for (int i = 1; i <= 100_000; i++) { Sorted_100_000.Add(i); }

			// Random lists
			Random_1000 = Sorted_1000.ToList();
			for (int i = Random_1000.Count - 1; i > 0; i--) {
				int j = rand.Next(i + 1);
				int temp = Random_1000[i];
				Random_1000[i] = Random_1000[j];
				Random_1000[j] = temp;
			}
			Random_100_000 = Sorted_100_000.ToList();
			for (int i = Random_100_000.Count - 1; i > 0; i--) {
				int j = rand.Next(i + 1);
				int temp = Random_100_000[i];
				Random_100_000[i] = Random_100_000[j];
				Random_100_000[j] = temp;
			}

			// Reverse lists
			List<int> Reverse_1000 = new List<int>(Sorted_1000);
			List<int> Reverse_100_000 = new List<int>(Sorted_1000);

			// Stop the stopwatch
			generationStopwatch.Stop();

			// Print how long list generation took
			Console.WriteLine($"List generation took {generationStopwatch.Elapsed.TotalMilliseconds} ms");
		}
	}
}
