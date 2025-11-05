using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace GraphSearches {
    public partial class DirectedWeightedGraph {

        // Performs a Depth-First Search (DFS) between two vertices.
        public void DepthFirstSearch(Vertex firstVertex, Vertex lastVertex, string outputFilePath) {
            // Validate that both start and end vertices exist in graph
            if (!adjacencyList.ContainsKey(firstVertex))
                throw new ArgumentException("Start vertex not found.");
            if (!adjacencyList.ContainsKey(lastVertex))
                throw new ArgumentException("End vertex not found.");

            // Stopwatch to measure algorithm execution time
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Tracks visited vertices to prevent revisiting nodes
            HashSet<Vertex> visited = new HashSet<Vertex>();

            // Stack holds tuples: (current vertex, current path, cumulative cost)
            Stack<(Vertex vertex, List<Vertex> path, int cost)> stack = new Stack<(Vertex, List<Vertex>, int)>();

            // For logging overall traversal order (not necessarily the final path)
            List<Vertex> fullPath = new List<Vertex>();
            int steps = 0;

            // Initialize search stack with starting vertex
            stack.Push((firstVertex, new List<Vertex> { firstVertex }, 0));

            while (stack.Count > 0) {
                // Pop next vertex from stack (DFS uses LIFO order)
                var (current, path, cost) = stack.Pop();
                steps++;

                visited.Add(current);
                fullPath.Add(current);

                // If destination is found, log and terminate
                if (current.Equals(lastVertex)) {
                    stopwatch.Stop();
                    using (StreamWriter writer = new StreamWriter(outputFilePath)) {
                        writer.WriteLine("DFS Travel Path:");
                        foreach (var v in fullPath)
                            writer.WriteLine(v.Id);

                        // Write details about discovered route
                        writer.WriteLine($"\nFinal Path: {string.Join(" -> ", path.ConvertAll(v => v.Id))}");
                        writer.WriteLine($"Number of Steps: {steps}");
                        writer.WriteLine($"Total Cost: {cost}");
                        writer.WriteLine($"Execution Time (ms): {stopwatch.ElapsedMilliseconds}");
                    }
                    return;
                }

                // Explore neighbors (push unvisited adjacent vertices)
                foreach (Edge edge in GetNeighbors(current)) {
                    if (!visited.Contains(edge.Destination)) {
                        // Create a copy of current path extended with destination
                        var newPath = new List<Vertex>(path) { edge.Destination };
                        stack.Push((edge.Destination, newPath, cost + edge.Weight));
                    }
                }
            }

            // If search completes with no path found
            stopwatch.Stop();
            using (StreamWriter writer = new StreamWriter(outputFilePath)) {
                writer.WriteLine("Program did not reach target vertex.");
            }
        }

        // Performs a Breadth-First Search (BFS) between two vertices.
        public void BreadthFirstSearch(Vertex firstVertex, Vertex lastVertex, string outputFilePath) {
            // Ensure both source and target vertices exist in the graph
            if (!adjacencyList.ContainsKey(firstVertex))
                throw new ArgumentException("Start vertex not found.");
            if (!adjacencyList.ContainsKey(lastVertex))
                throw new ArgumentException("Last vertex not found.");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            HashSet<Vertex> visited = new HashSet<Vertex>();

            // Queue for BFS (FIFO order), holding (vertex, path, cost)
            Queue<(Vertex, List<Vertex>, int)> queue = new Queue<(Vertex, List<Vertex>, int)>();

            // For full traversal path logging
            List<Vertex> fullPath = new List<Vertex>();
            int steps = 0;

            // Initialize queue with starting vertex
            queue.Enqueue((firstVertex, new List<Vertex> { firstVertex }, 0));

            while (queue.Count > 0) {
                var (current, path, cost) = queue.Dequeue();
                steps++;

                // Skip already visited nodes to avoid cycles
                if (visited.Contains(current))
                    continue;

                visited.Add(current);
                fullPath.Add(current);

                // If destination is reached
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

                // Add all unvisited neighbors to the queue
                foreach (Edge edge in GetNeighbors(current)) {
                    if (!visited.Contains(edge.Destination)) {
                        var newPath = new List<Vertex>(path) { edge.Destination };
                        queue.Enqueue((edge.Destination, newPath, cost + edge.Weight));
                    }
                }
            }

            // If no path found
            using (StreamWriter writer = new StreamWriter(outputFilePath))
                writer.WriteLine("Program did not reach target vertex");
        }

        // Executes Dijkstra’s Algorithm to find the shortest path between two vertices.
        public void Dijkstras(Vertex firstVertex, Vertex lastVertex, string outputFilePath) {
            // Ensure both vertices exist
            if (!adjacencyList.ContainsKey(firstVertex))
                throw new ArgumentException("Start vertex not found.");
            if (!adjacencyList.ContainsKey(lastVertex))
                throw new ArgumentException("Last vertex not found.");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Distance dictionary stores shortest known distance from start to each vertex
            var distance = new Dictionary<Vertex, int>();

            // Previous dictionary stores path information for reconstruction
            var previous = new Dictionary<Vertex, Vertex>();

            // Keeps track of processed vertices
            var visited = new HashSet<Vertex>();

            // Priority queue (sorted by cost, then vertex ID for tie-breaking)
            var pq = new SortedSet<(int cost, Vertex vertex)>(
                Comparer<(int, Vertex)>.Create((a, b) =>
                    a.Item1 == b.Item1 ? a.Item2.Id.CompareTo(b.Item2.Id) : a.Item1 - b.Item1)
            );

            // Initialize distances (infinity except for start vertex)
            foreach (var v in adjacencyList.Keys)
                distance[v] = int.MaxValue;

            distance[firstVertex] = 0;
            pq.Add((0, firstVertex));

            int steps = 0;

            while (pq.Count > 0) {
                // Retrieve vertex with smallest known distance
                var (cost, current) = pq.Min;
                pq.Remove(pq.Min);

                if (visited.Contains(current))
                    continue;

                visited.Add(current);
                steps++;

                // If destination reached, reconstruct path
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

                // Relax edges — update distances and enqueue neighbors
                foreach (var edge in GetNeighbors(current)) {
                    int newCost = cost + edge.Weight;
                    if (newCost < distance[edge.Destination]) {
                        distance[edge.Destination] = newCost;
                        previous[edge.Destination] = current;
                        pq.Add((newCost, edge.Destination));
                    }
                }
            }

            // If the end vertex was never reached
            using (StreamWriter writer = new StreamWriter(outputFilePath))
                writer.WriteLine("Program did not reach target vertex.");
        }
    }
}
