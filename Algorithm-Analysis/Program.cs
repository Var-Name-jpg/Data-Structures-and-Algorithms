using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;

namespace SortingBenchmark {
	public class Program {
		public static void Main(String[] args) {
			///////////////////////////////////////////////////////////////////////////////////////
			///                                                                                 ///
			///                                                                                 ///
			///                                                                                 ///
			/// Generation Code for Lists /////////////////////////////////////////////////////////
			///                                                                                 ///
			///                                                                                 ///
			///                                                                                 ///
			///////////////////////////////////////////////////////////////////////////////////////
			Random rand = new Random();

			// Diagnostic for generating numbers (for control)
			Stopwatch generationStopwatch = Stopwatch.StartNew();

			/// 1k lists ///
			
			// Sorted
			List<int> Sorted_1000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/sorted_1000.txt")) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					Sorted_1000.Add(int.Parse(line));
				}
			}

			// Random
			List<int> Random_1000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/random_1000.txt")) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					Random_1000.Add(int.Parse(line));
				}
			}

			// Reverse
			List<int> Reverse_1000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/reverse_1000.txt")) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					Reverse_1000.Add(int.Parse(line));
				}
			}

			/// 100k lists ///

			// Sorted
			List<int> Sorted_100_000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/sorted_100_000.txt")) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					Sorted_100_000.Add(int.Parse(line));
				}
			}

			// Random
			List<int> Random_100_000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/random_100_000.txt")) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					Random_100_000.Add(int.Parse(line));
				}
			}

			// Reverse
			List<int> Reverse_100_000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/reverse_100_000.txt")) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					Reverse_100_000.Add(int.Parse(line));
				}
			}

			
			
			// Parse words into a list
			List<string> words = new List<string>();
			using (StreamReader sr = new StreamReader("Data/Words.txt")) {
				string line;

				while ((line = sr.ReadLine()) != null) {
					words.Add(line);
				}
			}

			// Stop the stopwatch
			generationStopwatch.Stop();

			// Print how long it took to generate lists
			Console.WriteLine($"List generation took {generationStopwatch.Elapsed.TotalMilliseconds} ms");

			//////////////////////////////////////////////////////////////////////////////////////
			/////////////////////	INSERTION SORT	//////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////
			
			Console.WriteLine("\nInsertion Sort w/ 1000 integers");
			Console.WriteLine(new string('=', 20));

			// Run benchmarks
			double timeSorted_1000 = Benchmark(Sorted_1000, Sorting_Algs.InsertionSort);
			double timeRandom_1000 = Benchmark(Random_1000, Sorting_Algs.InsertionSort);
			double timeReverse_1000 = Benchmark(Reverse_1000, Sorting_Algs.InsertionSort);
			double timeWords = Benchmark(words, Sorting_Algs.InsertionSort);


			// Print the times for log
			Console.WriteLine($"Sorted: {timeSorted_1000} ms");
			Console.WriteLine($"Random: {timeRandom_1000} ms");
			Console.WriteLine($"Reverse: {timeReverse_1000} ms");
			Console.WriteLine($"Words: {timeWords} ms");
			Console.WriteLine(new string('=', 20));

			//////////////////////////////////////////////////////////////////////////////////////
			/////////////////////   QUICK     SORT  //////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////

			Console.WriteLine("\nQuick Sort w/ 1000 integers");
			Console.WriteLine(new string('=', 20));

			// Run benchmarks
			timeSorted_1000 = Benchmark(Sorted_1000, Sorting_Algs.QuickSort);
			timeRandom_1000 = Benchmark(Random_1000, Sorting_Algs.QuickSort);
			timeReverse_1000 = Benchmark(Reverse_1000, Sorting_Algs.QuickSort);
			timeWords = Benchmark(words, Sorting_Algs.QuickSort);

			// Print the times for log
			Console.WriteLine($"Sorted: {timeSorted_1000} ms");
			Console.WriteLine($"Random: {timeRandom_1000} ms");
			Console.WriteLine($"Reverse: {timeReverse_1000} ms");
			Console.WriteLine($"Words: {timeWords} ms");
			Console.WriteLine(new string('=', 20));
		}

		static double Benchmark<T>(List<T> input, SortAlgorithm<T> sorter) where T : IComparable<T> {
			// Force GC cleanup
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();

			// Clone input to avoid mutation
			var testInput = new List<T>(input);

			// Warm-Up for JIT
			sorter(new List<T>(testInput));

			// Reset GC to isolate timing
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();

			// Time benchmark
			Stopwatch timer = Stopwatch.StartNew();
			sorter(testInput);
			timer.Stop();

			return timer.Elapsed.TotalMilliseconds;
		}

		public delegate List<T> SortAlgorithm<T>(List<T> items) where T : IComparable<T>;
	}
}
