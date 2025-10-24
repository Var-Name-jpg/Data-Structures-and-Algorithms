using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace GraphSearches {
	public class Program {
		public static void Main(string[] args) {
			DirectedWeightedGraph graph = new DirectedWeightedGraph("Data-Files/graph_100_edges.csv");
			graph.PrintGraph();

			var result = graph.DepthFirstSearch();
		}
	}
}
