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
			Stopwatch timer = Stopwatch.StartNew();

			List<int> insertionSorted_1000 = new List<int>(Sorted_1000);
			insertionSorted_1000 = Sorting_Algs.InsertionSort(insertionSorted_1000);

			timer.Stop();
			double timeSorted_1000 = timer.Elapsed.TotalMilliseconds;

			// Insertion sort with random list
			timer = Stopwatch.StartNew();

			List<int> insertionRandom_1000 = new List<int>(Random_1000);
			insertionRandom_1000 = Sorting_Algs.InsertionSort(insertionRandom_1000);

			timer.Stop();
			double timeRandom_1000 = timer.Elapsed.TotalMilliseconds;

			// Insetion sort with reverse list
			timer = Stopwatch.StartNew();

			List<int> insertionReverse_1000 = new List<int>(Reverse_1000);
			insertionReverse_1000 = Sorting_Algs.InsertionSort(insertionReverse_1000);

			timer.Stop();
			double timeReverse_1000 = timer.Elapsed.TotalMilliseconds;

			// Insertion sort with text
			timer = Stopwatch.StartNew();

			List<string> insertionWords = new List<string>(words);
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
			/////////////////////   INSERTION SORT  //////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////               
		}
	}
}
