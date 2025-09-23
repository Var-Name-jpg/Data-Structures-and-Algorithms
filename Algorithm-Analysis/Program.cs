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

			//////////////////////////////////////////////////////////////////////////////////////
			/////////////////////   QUICK     SORT  //////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////

			Console.WriteLine("\n-------------------------------------------------------\n");

			// Run benchmarks for 1k lists
			double timeSorted_1000 = Benchmark(Sorted_1000, Sorting_Algs.QuickSort);
			double timeRandom_1000 = Benchmark(Random_1000, Sorting_Algs.QuickSort);
			double timeReverse_1000 = Benchmark(Reverse_1000, Sorting_Algs.QuickSort);

			// Run benchmarks for 100k lists
			double timeSorted_100_000 = Benchmark(Sorted_100_000, Sorting_Algs.QuickSort);
			double timeRandom_100_000 = Benchmark(Random_100_000, Sorting_Algs.QuickSort);
			double timeReverse_100_000 = Benchmark(Reverse_100_000, Sorting_Algs.QuickSort);

			// Run benchmark for 1k strings
			double timeWords = Benchmark(words, Sorting_Algs.QuickSort);

			// Print the times for log
			Console.WriteLine("Quick Sort w/ 1k integers");
			Console.WriteLine(new string('=', 20));

			Console.WriteLine($"Sorted: {timeSorted_1000} ms");
			Console.WriteLine($"Random: {timeRandom_1000} ms");
			Console.WriteLine($"Reverse: {timeReverse_1000} ms");

			Console.WriteLine(new string('=', 20));
			Console.WriteLine();

			Console.WriteLine("Quick Sort w/ 100k integers");
			Console.WriteLine(new string('=', 20));
			
			Console.WriteLine($"Sorted: {timeSorted_100_000} ms");
			Console.WriteLine($"Random: {timeRandom_100_000} ms");
			Console.WriteLine($"Reverse: {timeReverse_100_000} ms");

			Console.WriteLine(new string('=', 20));
			Console.WriteLine();

			Console.WriteLine("Quick Sort w/ 1k words");
			Console.WriteLine(new string('=', 20));
			Console.WriteLine($"Words: {timeWords} ms");
			Console.WriteLine(new string('=', 20));
			
			//////////////////////////////////////////////////////////////////////////////////////
			/////////////////////   Merge     SORT  //////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////

			Console.WriteLine("\n-------------------------------------------------------\n");

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

			// Print the times for log
			Console.WriteLine("Merge Sort w/ 1k integers");
			Console.WriteLine(new string('=', 20));

			Console.WriteLine($"Sorted: {timeSorted_1000} ms");
			Console.WriteLine($"Random: {timeRandom_1000} ms");
			Console.WriteLine($"Reverse: {timeReverse_1000} ms");

			Console.WriteLine(new string('=', 20));
			Console.WriteLine();

			Console.WriteLine("Merge Sort w/ 100k integers");
			Console.WriteLine(new string('=', 20));
			
			Console.WriteLine($"Sorted: {timeSorted_100_000} ms");
			Console.WriteLine($"Random: {timeRandom_100_000} ms");
			Console.WriteLine($"Reverse: {timeReverse_100_000} ms");

			Console.WriteLine(new string('=', 20));
			Console.WriteLine();

			Console.WriteLine("Merge Sort w/ 1k words");
			Console.WriteLine(new string('=', 20));
			Console.WriteLine($"Words: {timeWords} ms");
			Console.WriteLine(new string('=', 20));
			
			//////////////////////////////////////////////////////////////////////////////////////
			/////////////////////   Radix     SORT  //////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////

			Console.WriteLine("\n-------------------------------------------------------\n");

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

			// Print the times for log
			Console.WriteLine("Radix Sort w/ 1k integers");
			Console.WriteLine(new string('=', 20));

			Console.WriteLine($"Sorted: {timeSorted_1000} ms");
			Console.WriteLine($"Random: {timeRandom_1000} ms");
			Console.WriteLine($"Reverse: {timeReverse_1000} ms");

			Console.WriteLine(new string('=', 20));
			Console.WriteLine();

			Console.WriteLine("Radix Sort w/ 100k integers");
			Console.WriteLine(new string('=', 20));
			
			Console.WriteLine($"Sorted: {timeSorted_100_000} ms");
			Console.WriteLine($"Random: {timeRandom_100_000} ms");
			Console.WriteLine($"Reverse: {timeReverse_100_000} ms");

			Console.WriteLine(new string('=', 20));
			Console.WriteLine();

			Console.WriteLine("Radix Sort w/ 1k words");
			Console.WriteLine(new string('=', 20));
			Console.WriteLine($"Words: {timeWords} ms");
			Console.WriteLine(new string('=', 20));
			
			//////////////////////////////////////////////////////////////////////////////////////
			/////////////////////	INSERTION SORT	//////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////

			Console.WriteLine("\n-------------------------------------------------------\n");

			// Run benchmarks for 1k lists
			timeSorted_1000 = Benchmark(Sorted_1000, Sorting_Algs.InsertionSort);
			timeRandom_1000 = Benchmark(Random_1000, Sorting_Algs.InsertionSort);
			timeReverse_1000 = Benchmark(Reverse_1000, Sorting_Algs.InsertionSort);

			// Run benchmarks for 100k lists
			timeSorted_100_000 = Benchmark(Sorted_100_000, Sorting_Algs.InsertionSort);
			timeRandom_100_000 = Benchmark(Random_100_000, Sorting_Algs.InsertionSort);
			timeReverse_100_000 = Benchmark(Reverse_100_000, Sorting_Algs.InsertionSort);
			
			// Run benchmarks for 1k strings
			timeWords = Benchmark(words, Sorting_Algs.InsertionSort);

			// Print the times for log
			Console.WriteLine("Insertion Sort w/ 1k integers");
			Console.WriteLine(new string('=', 20));

			Console.WriteLine($"Sorted: {timeSorted_1000} ms");
			Console.WriteLine($"Random: {timeRandom_1000} ms");
			Console.WriteLine($"Reverse: {timeReverse_1000} ms");

			Console.WriteLine(new string('=', 20));
			Console.WriteLine();

			Console.WriteLine("Insertion Sort w/ 100k integers");
			Console.WriteLine(new string('=', 20));
			
			Console.WriteLine($"Sorted: {timeSorted_100_000} ms");
			Console.WriteLine($"Random: {timeRandom_100_000} ms");
			Console.WriteLine($"Reverse: {timeReverse_100_000} ms");

			Console.WriteLine(new string('=', 20));
			Console.WriteLine();

			Console.WriteLine("Insertion Sort w/ 1k words");
			Console.WriteLine(new string('=', 20));
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
