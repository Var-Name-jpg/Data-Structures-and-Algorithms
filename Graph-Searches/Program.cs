using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace GraphSearches {
	public class Program {
		public static void Main(string[] args) {
			DirectedWeightedGraph graph100 = new DirectedWeightedGraph("Data-Files/graph_100_edges.csv");
			DirectedWeightedGraph graph1k = new DirectedWeightedGraph("Data-Files/graph_1000_edges.csv");
			DirectedWeightedGraph graph10k = new DirectedWeightedGraph("Data-Files/graph_10000_edges.csv");

			Vertex startVert100 = new Vertex("sly spider");
			Vertex lastVert100 = new Vertex("granite firefly");

			var result = graph100.DepthFirstSearch(startVert100, lastVert100, "output-files/DFS-Search-100.txt");
		}
	}
}
