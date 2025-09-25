## 🧮 Sorting Algorithm Benchmark Suite

### 🔧 Overview
This project benchmarks the performance of four sorting algorithms — **Insertion Sort**, **Merge Sort**, **Radix Sort**, and **QuickSort** — across multiple input types. Each algorithm is run 30 times per dataset to ensure statistical reliability, with results printed to the console and saved to a CSV file.

### 📊 Algorithms Benchmarked
- **Insertion Sort** — Simple, stable, efficient for small or nearly sorted data  
- **Merge Sort** — Divide-and-conquer, stable, consistent O(n log n)  
- **Radix Sort** — Non-comparative, fast for fixed-width integers  
- **QuickSort** — Recursive, fast average-case, sensitive to input shape  

### 📁 Input Datasets
All datasets are located in the `Data/` folder. These include a variety of integer and string lists used to test algorithm performance under different conditions. The full list is extensive and not enumerated here.

### 🧪 Benchmarking Details
- Each algorithm runs **30 consecutive trials** per dataset  
- JIT compilation is warmed up before timing  
- Garbage collection is reset before each timed run  
- Results are printed to console and saved to `benchmark_results.csv`

### 📈 CSV Output Format
The CSV file contains one row per algorithm, with average timings across each dataset:
```
Algorithm,1k-Sorted,1k-Random,1k-Reverse,100k-Sorted,100k-Random,100k-Reverse,1k-Strings
```

### 🚀 How to Run
Run the benchmark once using:
```bash
dotnet run
```

Running multiple times is unnecessary, as the program already performs 30 trials per dataset internally.

> ⚠️ **Note**: On a Ryzen 9 9900X3D, the full benchmark suite took approximately **1.5 hours** to complete. Long runtimes are expected due to repeated trials and large input sizes.
