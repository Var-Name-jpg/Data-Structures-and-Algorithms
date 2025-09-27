using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using System.Threading.Tasks;

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

			/// 1k lists ///
			
			// Sorted
			List<int> Sorted_1000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/sorted_1000.txt")) {
				string? line;
				while ((line = sr.ReadLine()) != null) {
					Sorted_1000.Add(int.Parse(line));
				}
			}

			// Random
			List<int> Random_1000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/random_1000.txt")) {
				string? line;
				while ((line = sr.ReadLine()) != null) {
					Random_1000.Add(int.Parse(line));
				}
			}

			// Reverse
			List<int> Reverse_1000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/reverse_1000.txt")) {
				string? line;
				while ((line = sr.ReadLine()) != null) {
					Reverse_1000.Add(int.Parse(line));
				}
			}

			/// 100k lists ///

			// Sorted
			List<int> Sorted_100_000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/sorted_100_000.txt")) {
				string? line;
				while ((line = sr.ReadLine()) != null) {
					Sorted_100_000.Add(int.Parse(line));
				}
			}

			// Random
			List<int> Random_100_000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/random_100_000.txt")) {
				string? line;
				while ((line = sr.ReadLine()) != null) {
					Random_100_000.Add(int.Parse(line));
				}
			}

			// Reverse
			List<int> Reverse_100_000 = new List<int>();
			using (StreamReader sr = new StreamReader("Data/reverse_100_000.txt")) {
				string? line;
				while ((line = sr.ReadLine()) != null) {
					Reverse_100_000.Add(int.Parse(line));
				}
			}

			
			
			// Parse words into a list
			List<string> words = new List<string>();
			using (StreamReader sr = new StreamReader("Data/Words.txt")) {
				string? line;

				while ((line = sr.ReadLine()) != null) {
					words.Add(line);
				}
			}

			using (StreamWriter sw = new StreamWriter("Data.csv", false)) {
				sw.WriteLine("Algorithm,Sorted-1k,Random-1k,Reverse-1k,Sorted-100k,Random-100k,Reverse-100k,Strings");
				sw.WriteLine("");
			}

			double timeSorted_1000, timeRandom_1000, timeReverse_1000;
			double timeSorted_100_000, timeRandom_100_000, timeReverse_100_000;
			double timeWords;

			double timeSorted_1k_Average = 0;
			double timeRandom_1k_Average = 0;
			double timeReverse_1k_Average = 0;
			double timeSorted_100k_Average = 0;
			double timeRandom_100k_Average = 0;
			double timeReverse_100k_Average = 0;
			double timeWords_Average = 0;

			int iterations = 30;

			var quickTasks = new List<Task<double[]>>();

			//////////////////////////////////////////////////////////////////////////////////////
			/////////////////////   Insertion     SORT  //////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////
			for (int i = 0; i < iterations; i++) {
				quickTasks.Add(Task.Run(() => {
					double[] results = new double[7];

					// Run benchmarks for 1k lists
					results[0] = Benchmark(Sorted_1000, Sorting_Algs.InsertionSort);
					results[1] = Benchmark(Random_1000, Sorting_Algs.InsertionSort);
					results[2] = Benchmark(Reverse_1000, Sorting_Algs.InsertionSort);

					// Run benchmarks for 100k lists
					results[3] = Benchmark(Sorted_100_000, Sorting_Algs.InsertionSort);
					results[4] = Benchmark(Random_100_000, Sorting_Algs.InsertionSort);
					results[5] = Benchmark(Reverse_100_000, Sorting_Algs.InsertionSort);

					// Run benchmark for 1k strings
					results[6] = Benchmark(words, Sorting_Algs.InsertionSort);

					return results;
				}));
			}

			Task.WaitAll(quickTasks.ToArray());

			using (StreamWriter sw = new StreamWriter("Data.csv", true)) {
				for (int i = 0; i < iterations; i++) {
					var results = quickTasks[i].Result;
					sw.WriteLine($"Insertion {i},{results[0]},{results[1]},{results[2]},{results[3]},{results[4]},{results[5]},{results[6]}");
				}

				sw.WriteLine();
			}
			
			//////////////////////////////////////////////////////////////////////////////////////
			/////////////////////   Merge     SORT  //////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////
			for (int i = 0; i < iterations; i++) {
				// Run benchmarks for 1k lists
				timeSorted_1000 = Benchmark(Sorted_1000, Sorting_Algs.MergeSort);
				timeRandom_1000 = Benchmark(Random_1000, Sorting_Algs.MergeSort);
				timeReverse_1000 = Benchmark(Reverse_1000, Sorting_Algs.MergeSort);

				// Run benchmarks for 100k lists
				timeSorted_100_000 = Benchmark(Sorted_100_000, Sorting_Algs.MergeSort);
				timeRandom_100_000 = Benchmark(Random_100_000, Sorting_Algs.MergeSort);
				timeReverse_100_000 = Benchmark(Reverse_100_000, Sorting_Algs.MergeSort);

				// Run benchmark for 1k strings
				timeWords = Benchmark(words, Sorting_Algs.MergeSort);
	
				using (StreamWriter sw = new StreamWriter("Data.csv", true)) {
					sw.WriteLine($"Merge {i},{timeSorted_1000},{timeRandom_1000},{timeReverse_1000},{timeSorted_100_000},{timeRandom_100_000},{timeReverse_100_000},{timeWords}");
				}
			}

			using (StreamWriter sw = new StreamWriter("Data.csv", true)) {
				sw.WriteLine();
			}
			
			//////////////////////////////////////////////////////////////////////////////////////
			/////////////////////   Radix     SORT  //////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////
			for (int i = 0; i < iterations; i++) {
				// Run benchmarks for 1k lists
				timeSorted_1000 = Benchmark(Sorted_1000, Sorting_Algs.RadixSortIntegers);
				timeRandom_1000 = Benchmark(Random_1000, Sorting_Algs.RadixSortIntegers);
				timeReverse_1000 = Benchmark(Reverse_1000, Sorting_Algs.RadixSortIntegers);

				// Run benchmarks for 100k lists
				timeSorted_100_000 = Benchmark(Sorted_100_000, Sorting_Algs.RadixSortIntegers);
				timeRandom_100_000 = Benchmark(Random_100_000, Sorting_Algs.RadixSortIntegers);
				timeReverse_100_000 = Benchmark(Reverse_100_000, Sorting_Algs.RadixSortIntegers);

				// Run benchmark for 1k strings
				timeWords = Benchmark(words, Sorting_Algs.RadixSortStrings);
	
				using (StreamWriter sw = new StreamWriter("Data.csv", true)) {
					sw.WriteLine($"Radix {i},{timeSorted_1000},{timeRandom_1000},{timeReverse_1000},{timeSorted_100_000},{timeRandom_100_000},{timeReverse_100_000},{timeWords}");
				}
			}

			using (StreamWriter sw = new StreamWriter("Data.csv", true)) {
				sw.WriteLine();
			}

			//////////////////////////////////////////////////////////////////////////////////////
			/////////////////////	Quick  SORT	//////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////
			for (int i = 0; i < iterations; i++) {
				// Run benchmarks for 1k lists
				timeSorted_1000 = Benchmark(Sorted_1000, Sorting_Algs.InsertionSort);
				timeRandom_1000 = Benchmark(Random_1000, Sorting_Algs.InsertionSort);
				timeReverse_1000 = Benchmark(Reverse_1000, Sorting_Algs.InsertionSort);

				// Run benchmarks for 100k lists
				timeSorted_100_000 = Benchmark(Sorted_100_000, Sorting_Algs.InsertionSort);
				timeRandom_100_000 = Benchmark(Random_100_000, Sorting_Algs.InsertionSort);
				timeReverse_100_000 = Benchmark(Reverse_100_000, Sorting_Algs.InsertionSort);

				// Run benchmark for 1k strings
				timeWords = Benchmark(words, Sorting_Algs.InsertionSort);
	
				using (StreamWriter sw = new StreamWriter("Data.csv", true)) {
					sw.WriteLine($"Quick {i},{timeSorted_1000},{timeRandom_1000},{timeReverse_1000},{timeSorted_100_000},{timeRandom_100_000},{timeReverse_100_000},{timeWords}");
				}
				
			}

			using (StreamWriter sw = new StreamWriter("Data.csv", true)) {
				sw.WriteLine();
			}
			
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

			return Math.Round(timer.Elapsed.TotalMilliseconds, 2);
		}

		public delegate List<T> SortAlgorithm<T>(List<T> items) where T : IComparable<T>;
	}
}
