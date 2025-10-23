using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace GraphSearches {
	public class Program {
		public static void Main(string[] args) {
			DirectedWeightedGraph<string> graph = new DirectedWeightedGraph<string>("Data-Files/graph_100_edges.csv");
		}
	}
}
