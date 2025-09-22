using System;
using System.Collections.Generic;
using System.Diagnostics;

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
			List<int> Reverse_1000 = new List<int>();
			List<int> Reverse_100_000 = new List<int>();

			for (int i = 1_000; i > 0; i--) { Reverse_1000.Add(i); }
			for (int i = 100_000; i > 0; i--) { Reverse_100_000.Add(i); }

			// Parse words into a list
			List<string> words = new List<string>();
			using (StreamReader sr = new StreamReader("Words.txt")) {
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

			// Insertion sort with sorted list
			List<int> insertionSorted_1000 = new List<int>(Sorted_1000);
			
			Stopwatch timer = Stopwatch.StartNew();
			insertionSorted_1000 = Sorting_Algs.InsertionSort(insertionSorted_1000);
			timer.Stop();

			double timeSorted_1000 = timer.Elapsed.TotalMilliseconds;

			// Insertion sort with random list
			List<int> insertionRandom_1000 = new List<int>(Random_1000);
			
			timer = Stopwatch.StartNew();
			insertionRandom_1000 = Sorting_Algs.InsertionSort(insertionRandom_1000);
			timer.Stop();

			double timeRandom_1000 = timer.Elapsed.TotalMilliseconds;

			// Insetion sort with reverse list
			List<int> insertionReverse_1000 = new List<int>(Reverse_1000);
			
			timer = Stopwatch.StartNew();
			insertionReverse_1000 = Sorting_Algs.InsertionSort(insertionReverse_1000);
			timer.Stop();

			double timeReverse_1000 = timer.Elapsed.TotalMilliseconds;

			// Insertion sort with text
			List<string> insertionWords = new List<string>(words);
			
			timer = Stopwatch.StartNew();
			insertionWords = Sorting_Algs.InsertionSort(insertionWords);
			timer.Stop();

			double timeWords = timer.Elapsed.TotalMilliseconds;

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

			// Quick sort with sorted list
			/*
			List<int> quickSorted_1000 = new List<int>(Sorted_1000);
			
			timer = Stopwatch.StartNew();
			quickSorted_1000 = Sorting_Algs.QuickSort(quickSorted_1000);
			timer.Stop();

			timeSorted_1000 = timer.Elapsed.TotalMilliseconds;

			// Quick sort with random list
			List<int> quickRandom_1000 = new List<int>(Random_1000);
			
			timer = Stopwatch.StartNew();
			quickRandom_1000 = Sorting_Algs.QuickSort(quickRandom_1000);
			timer.Stop();

			timeRandom_1000 = timer.Elapsed.TotalMilliseconds;
			
			*/

			// Quick sort with reverse list
			List<int> quickReverse_1000 = new List<int>(Reverse_1000);
			
			timer = Stopwatch.StartNew();
			quickReverse_1000 = Sorting_Algs.QuickSort(quickReverse_1000);
			timer.Stop();

			timeReverse_1000 = timer.Elapsed.TotalMilliseconds;

			// Quick sort with text
			List<string> quickWords = new List<string>(words);

			timer = Stopwatch.StartNew();
			quickWords = Sorting_Algs.QuickSort(quickWords);
			timer.Stop();

			timeWords = timer.Elapsed.TotalMilliseconds;

			// Print the times for log
			// Console.WriteLine($"Sorted: {timeSorted_1000} ms");
			// Console.WriteLine($"Random: {timeRandom_1000} ms");
			Console.WriteLine($"Reverse: {timeReverse_1000} ms");
			Console.WriteLine($"Words: {timeWords} ms");
			Console.WriteLine(new string('=', 20));
		}
	}
}
