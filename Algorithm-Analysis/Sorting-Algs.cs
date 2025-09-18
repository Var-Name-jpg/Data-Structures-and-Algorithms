namespace SortingBenchmark {
	// Insertion Sort
	public List<T> InsertionSort<T>(List<T> items) where T : IComparable<T> {
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
	public List<T> QuickSort<T>(List<T> items) where T : IComparable<T> {
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
	public List<T> MergeSort<T>(List<T> items) where T : IComparable<T> {
		if (items.Count <= 1) { return items; }

		int mid = items.Count / 2;
		List<T> left = items.GetRange(0, mid);
		List<T> right = items.GetRange(mid, items.Count - mid);

		return Merge(MergeSort(left), MergeSort(right));
	}

	public List<T> Merge<T>(List<T> left, List<T> right) where T : IComparable<T> {
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
	public List<int> RadixSortIntegers(List<int> items) {
		
}

