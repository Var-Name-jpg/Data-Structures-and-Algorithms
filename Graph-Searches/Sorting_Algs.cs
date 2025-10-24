using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace GraphSearches {
       public partial class DirectedWeightedGraph {
		public (List<Vertex> path, int steps, long timeMs, int totalCost) DepthFirstSearch(Vertex firstVertex, Vertex lastVertex, string outputFilePath) {
			if (!adjacencyList.ContainsKey(firstVertex))
				throw new ArgumentException("Start vertex not found.");
			if (!adjacencyList.ContainsKey(lastVertex))
				throw new ArgumentException("End vertex not found.");

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			HashSet<Vertex> visited = new HashSet<Vertex>();
			Stack<(Vertex vertex, List<Vertex> path, int cost)> stack = new Stack<(Vertex, List<Vertex>, int)>();

			List<Vertex> fullPath = new List<Vertex>();
			int steps = 0;
			int totalCost = 0;

			stack.Push((firstVertex, new List<Vertex> { firstVertex }, 0));

			while (stack.Count > 0) {
				var (current, path, cost) = stack.Pop();
				steps++;
				visited.Add(current);

				fullPath.Add(current);

				if (current.Equals(lastVertex)) {
					stopwatch.Stop();

					using (StreamWriter writer = new StreamWriter(outputFilePath)) {
						writer.WriteLine("DFS Travel Path:");
						foreach (var v in fullPath)
							writer.WriteLine(v.Id);

						writer.WriteLine($"\nFinal Path: {string.Join(" -> ", path.ConvertAll( v => v.Id))}");
						writer.WriteLine($"Number of Steps: {steps}");
						writer.WriteLine($"Total Cost: {cost}");
						writer.WriteLine($"Execution Time (ms): {stopwatch.ElapsedMilliseconds}");
					}

					return (path, steps, stopwatch.ElapsedMilliseconds, cost);
				}

				foreach (Edge edge in GetNeighbors(current)) {
					if (!visited.Contains(edge.Destination)) {
						var newPath = new List<Vertex>(path) { edge.Destination };
						stack.Push((edge.Destination, newPath, cost + edge.Weight));
					}
				}
			}

			stopwatch.Stop();

			// If destination not reached, write an error log
			using (StreamWriter writer = new StreamWriter(outputFilePath)) {
				writer.WriteLine("Program did not reach target vertex.");
			}

			return (new List<Vertex>(), steps, stopwatch.ElapsedMilliseconds, totalCost);
		}
	}
}
