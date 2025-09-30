namespace SortingBenchmark {
	public static class Sorting_Algs {
		// Insertion Sort
		public static List<T> InsertionSort<T>(List<T> items) where T : IComparable<T> {
			for (int i = 1; i < items.Count; i++) {
				T key = items[i];
				int j = i - 1;

				while (j >= 0 && items[j].CompareTo(key) > 0) {
					items[j + 1] = items[j];
					j--;
				}
				
				items[j + 1] = key;
			}
			return items;
		}

		// Quick Sort
		public static List<T> QuickSort<T>(List<T> items) where T : IComparable<T> {
			if (items.Count <= 1) { return items; }

			T pivot = items[items.Count / 2];
			List<T> less = new List<T>();
			List<T> equal = new List<T>();
			List<T> greater = new List<T>();

			foreach (T item in items) {
				int comparison = item.CompareTo(pivot);
				if (comparison < 0) { less.Add(item); }
				else if (comparison > 0) { greater.Add(item); }
				else { equal.Add(item); }
			}

			List<T> sorted = new List<T>();
			sorted.AddRange(QuickSort(less));
			sorted.AddRange(equal);
			sorted.AddRange(QuickSort(greater));

			return sorted;
		}

		// Merge Sort
		public static List<T> MergeSort<T>(List<T> items) where T : IComparable<T> {
			if (items.Count <= 1) { return items; }

			int mid = items.Count / 2;
			List<T> left = items.GetRange(0, mid);
			List<T> right = items.GetRange(mid, items.Count - mid);

			return Merge(MergeSort(left), MergeSort(right));
		}

		public static List<T> Merge<T>(List<T> left, List<T> right) where T : IComparable<T> {
			List<T> result = new List<T>();
			int i = 0, j = 0;

			while (i < left.Count && j < right.Count) {
				if (left[i].CompareTo(right[j]) <= 0) {
					result.Add(left[i]);
					i++;
				} else {
					result.Add(right[j]);
					j++;
				}
			}

			result.AddRange(left.GetRange(i, left.Count - i));
			result.AddRange(right.GetRange(j, right.Count - j));

			return result;
		}

		// Radix Sort (integers)
		public static List<int> RadixSortIntegers(List<int> items) {
			int max = items.Max();
			int exp = 1;

			while (max / exp > 0) {
				List<int>[] buckets = new List<int>[10];

				for (int i = 0; i < 10; i++) { buckets[i] = new List<int>(); }
				foreach (int item in items) {
					int digit = (item / exp) % 10;
					buckets[digit].Add(item);
				}

				items.Clear();

				foreach (var bucket in buckets) { items.AddRange(bucket); }

				exp *= 10;
			}

			return items;

		}

		// Radix Sort (strings)
		public static List<string> RadixSortStrings(List<string> items) {
			int maxLength = items.Max(s => s.Length);

			for (int pos = maxLength - 1; pos >= 0; pos--) {
				List<string>[] buckets = new List<string>[256];
				for (int i = 0; i < 256; i++) { buckets[i] = new List<string>(); }

				foreach (string item in items) {
					char c = pos < item.Length ? item[pos] : '\0';
					buckets[c].Add(item);
				}

				items.Clear();
				foreach (var bucket in buckets) { items.AddRange(bucket); }
			}

			return items;
		}
	}
}
