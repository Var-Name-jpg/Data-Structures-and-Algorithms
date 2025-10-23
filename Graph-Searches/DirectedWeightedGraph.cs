using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace GraphSearches {
	public class Edge {
		public Vertex Destination { get; set; }
		public int Weight { get; set; }
		
		public Edge(Vertex destination, int weight) {
			Destination = destination;
			Weight = weight;
		}
	}

	public class Vertex {
		public string Id { get; set; }

		public Vertex(string id) {
			Id = id;
		}
	}

	public class DirectedWeightedGraph<T> {
		private Dictionary< Vertex, List<Edge> > adjacencyList;

		public DirectedWeightedGraph(string filePath) {
			foreach (string line in File.ReadLines(filePath)) {
				List<string> tempData = line.Split(',').ToList();
			}
		}
	}

	public void AddVertexEdgePair(Vertex vertex) {
		foreach (Vertex compVert in adjacencyList.Keys) {
			if (compVert == vertex)
				return;
		}

		adjacencyList.Add(vertex, new List<Edge>());
	}


}
