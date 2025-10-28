using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace GraphSearches {
       public partial class DirectedWeightedGraph {
		public void DepthFirstSearch(Vertex firstVertex, Vertex lastVertex, string outputFilePath) {
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

					return;

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
		}

		public void BreadthFirstSearch(Vertex firstVertex, Vertex lastVertex, string outputFilePath) {
			if (!adjacencyList.ContainsKey(firstVertex))
				throw new ArgumentException("Start vertex not found.");
			if (!adjacencyList.ContainsKey(lastVertex))
				throw new ArgumentException("Last vertex not found.");

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			HashSet<Vertex> visited = new HashSet<Vertex>();
			Queue<(Vertex, List<Vertex>, int)> queue = new Queue<(Vertex, List<Vertex>, int)>();
			List<Vertex> fullPath = new List<Vertex>();

			int steps = 0;

			queue.Enqueue((firstVertex, new List<Vertex> { firstVertex }, 0));

			while (queue.Count > 0) {
				var (current, path, cost) = queue.Dequeue();
				steps++;
				if (visited.Contains(current))
					continue;

				visited.Add(current);
				fullPath.Add(current);

				if (current.Equals(lastVertex)) {
					stopwatch.Stop();
					using (StreamWriter writer = new StreamWriter(outputFilePath)) {
						writer.WriteLine("BFS Travel Path:");
						foreach (var v in fullPath)
							writer.WriteLine(v.Id);

						writer.WriteLine("Path: " + string.Join(" -> ", path.ConvertAll(v => v.Id)));
						writer.WriteLine($"Steps: {steps}");
						writer.WriteLine($"Total Cost: {cost}");
						writer.WriteLine($"Execution Time (ms): {stopwatch.ElapsedMilliseconds}");
					}

					return;
				}

				foreach (Edge edge in GetNeighbors(current)) {
					if (!visited.Contains(edge.Destination)) {
						var newPath = new List<Vertex>(path) { edge.Destination };
						queue.Enqueue((edge.Destination, newPath, cost + edge.Weight));
					}
				}
			}

			using (StreamWriter writer = new StreamWriter(outputFilePath))
				writer.WriteLine("Program did not reach target vertex");

		}

		public void Dijkstras(Vertex firstVertex, Vertex lastVertex, string outputFilePath) {
			if (!adjacencyList.ContainsKey(firstVertex))
				throw new ArgumentException("Start vertex not found.");
			if (!adjacencyList.ContainsKey(lastVertex))
				throw new ArgumentException("Last vertex not found.");

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			var distance = new Dictionary<Vertex, int>();
			var previous = new Dictionary<Vertex, Vertex>();
			var visited = new HashSet<Vertex>();
			var pq = new SortedSet<(int cost, Vertex vertex)>(Comparer<(int, Vertex)>.Create((a, b) => a.Item1 == b.Item1 ? a.Item2.Id.CompareTo(b.Item2.Id) : a.Item1 - b.Item1));

			foreach (var v in adjacencyList.Keys)
				distance[v] = int.MaxValue;
			distance[firstVertex] = 0;
			pq.Add((0, firstVertex));

			int steps = 0;

			while (pq.Count > 0) {
				var (cost, current) = pq.Min;
				pq.Remove(pq.Min);

				if (visited.Contains(current))
					continue;
				visited.Add(current);
				steps++;

				if (current.Equals(lastVertex)) {
					stopwatch.Stop();
					var path = new List<Vertex>();
					for (var v = lastVertex; v != null; v = previous.ContainsKey(v) ? previous[v] : null)
						path.Add(v);
					path.Reverse();

					using (StreamWriter writer = new StreamWriter(outputFilePath)) {
						writer.WriteLine("Dijkstra's Travel Path:");
						foreach (var v in path)
							writer.WriteLine(v.Id);
						writer.WriteLine("Path: " + string.Join(" -> ", path.ConvertAll(v => v.Id)));
						writer.WriteLine($"Steps: {steps}");
						writer.WriteLine($"Total Cost: {cost}");
						writer.WriteLine($"Execution Time (ms): {stopwatch.ElapsedMilliseconds}");
					}

					return;
				}

				foreach (var edge in GetNeighbors(current)) {
					int newCost = cost + edge.Weight;
					if (newCost < distance[edge.Destination]) {
						distance[edge.Destination] = newCost;
						previous[edge.Destination] = current;
						pq.Add((newCost, edge.Destination));
					}
				}
			}

			using (StreamWriter writer = new StreamWriter(outputFilePath))
				writer.WriteLine("Program did not reach target vertex.");
		}
	}
}
