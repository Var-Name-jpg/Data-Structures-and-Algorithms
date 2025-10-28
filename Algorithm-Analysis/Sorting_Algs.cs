namespace SortingBenchmark {
    public static class Sorting_Algs {
        // Insertion Sort
        // Sorts the list in place using the insertion sort algorithm.
        // Works by taking elements one by one and inserting them into their correct position in the sorted left portion.
        // Time Complexity: O(n^2) in worst and average cases.
        // Space Complexity: O(1) additional space.
        // Generic implementation constrained to elements implementing IComparable<T> for comparison.
        public static List<T> InsertionSort<T>(List<T> items) where T : IComparable<T> {
            for (int i = 1; i < items.Count; i++) {  // Start from the second element to insert it into sorted subarray
                T key = items[i];                    // Element to insert
                int j = i - 1;

                // Shift elements greater than key to the right to make room for key
                while (j >= 0 && items[j].CompareTo(key) > 0) {
                    items[j + 1] = items[j];
                    j--;
                }
                
                // Insert key after the last shifted element
                items[j + 1] = key;
            }
            return items; // Sorted list returned (same list reference)
        }


        // Quick Sort
        // Sorts the list using the Quick Sort algorithm.
        // Uses divide-and-conquer by selecting a pivot, partitioning the list around it, then recursively sorting partitions.
        // Time Complexity: Average O(n log n), Worst O(n^2) if pivot is poor.
        // Space Complexity: O(n) for the recursive calls and new lists created.
        // Generic implementation with IComparable<T> constraint.
        public static List<T> QuickSort<T>(List<T> items) where T : IComparable<T> {
            if (items.Count <= 1) { return items; } // Base case: list of size 0 or 1 is already sorted.

            // Choose pivot as middle element
            T pivot = items[items.Count / 2];
            List<T> less = new List<T>();   // Elements less than pivot
            List<T> equal = new List<T>();  // Elements equal to pivot
            List<T> greater = new List<T>(); // Elements greater than pivot

            // Partition items into less, equal, greater lists based on comparison with pivot
            foreach (T item in items) {
                int comparison = item.CompareTo(pivot);
                if (comparison < 0) { less.Add(item); }
                else if (comparison > 0) { greater.Add(item); }
                else { equal.Add(item); }
            }

            List<T> sorted = new List<T>();
            // Recursively sort less and greater lists and concatenate with equal items
            sorted.AddRange(QuickSort(less));
            sorted.AddRange(equal);
            sorted.AddRange(QuickSort(greater));

            return sorted; // Return concatenated sorted list
        }


        // Merge Sort
        // Sorts the list using the Merge Sort algorithm.
        // Recursively divides the list into halves, sorts each half, then merges the sorted halves.
        // Time Complexity: O(n log n) in all cases.
        // Space Complexity: O(n) due to auxiliary lists used in merging.
        public static List<T> MergeSort<T>(List<T> items) where T : IComparable<T> {
            if (items.Count <= 1) { return items; } // Base case: empty or single-element lists are sorted.

            int mid = items.Count / 2; // Find midpoint to divide the list

            // Split list into left and right halves
            List<T> left = items.GetRange(0, mid);
            List<T> right = items.GetRange(mid, items.Count - mid);

            // Recursively sort each half, then merge them into a sorted list
            return Merge(MergeSort(left), MergeSort(right));
        }

        // Helper method for MergeSort
        // Merges two sorted lists (left and right) into one sorted list.
        private static List<T> Merge<T>(List<T> left, List<T> right) where T : IComparable<T> {
            List<T> result = new List<T>();
            int i = 0, j = 0;

            // Compare elements from both lists and add the smaller to result
            while (i < left.Count && j < right.Count) {
                if (left[i].CompareTo(right[j]) <= 0) {
                    result.Add(left[i]);
                    i++;
                } else {
                    result.Add(right[j]);
                    j++;
                }
            }

            // Append any remaining elements after one list is exhausted
            result.AddRange(left.GetRange(i, left.Count - i));
            result.AddRange(right.GetRange(j, right.Count - j));

            return result; // Merged, sorted list
        }


        // Radix Sort (for integers)
        // Sorts a list of non-negative integers using LSD radix sort.
        // Sorts by individual digits starting from the least significant digit progressing to the most.
        // Time Complexity: O(d * n), where d = number of digits in the max integer.
        // Space Complexity: O(n + b), b = base (here 10).
        public static List<int> RadixSortIntegers(List<int> items) {
            int max = items.Max(); // Find max to know number of digits
            int exp = 1;           // Exponent to isolate digit (1s, 10s, 100s...)

            // Continue sorting digits until all digit places are processed
            while (max / exp > 0) {
                // Create buckets for digits 0-9
                List<int>[] buckets = new List<int>[10];
                for (int i = 0; i < 10; i++) { buckets[i] = new List<int>(); }

                // Place each number into bucket corresponding to current digit
                foreach (int item in items) {
                    int digit = (item / exp) % 10;
                    buckets[digit].Add(item);
                }

                items.Clear(); // Clear original list

                // Concatenate buckets back in order
                foreach (var bucket in buckets) { items.AddRange(bucket); }

                exp *= 10; // Move to next more significant digit
            }

            return items; // Sorted integer list
        }


        // Radix Sort (for strings)
        // Sorts a list of strings based on character positions right to left (LSD string radix sort).
        // Works with ASCII or Unicode characters by using 256 buckets.
        // Time Complexity: O(d * n), where d = max string length.
        // Space Complexity: O(n + k), k=256 buckets.
        public static List<string> RadixSortStrings(List<string> items) {
            int maxLength = items.Max(s => s.Length); // Find longest string length

            // Process from last character position (rightmost) to first (leftmost)
            for (int pos = maxLength - 1; pos >= 0; pos--) {
                // Create 256 buckets for each possible character code (0-255)
                List<string>[] buckets = new List<string>[256];
                for (int i = 0; i < 256; i++) { buckets[i] = new List<string>(); }

                foreach (string item in items) {
                    // If string shorter than current position, assign '\0' (null) char bucket
                    char c = pos < item.Length ? item[pos] : '\0';
                    buckets[c].Add(item);
                }

                items.Clear(); // Clear list before re-adding from buckets

                // Concatenate buckets back in order of character codes
                foreach (var bucket in buckets) { items.AddRange(bucket); }
            }

            return items; // Sorted string list
        }
    }
}
