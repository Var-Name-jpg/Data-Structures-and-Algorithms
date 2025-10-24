using System;
using System.Collections;
using System.Collections.Generic;

namespace GraphSearches {
	public partial class DirectedWeightedGraph {
		public (List<Vertex> path, int steps, long timeMs, int totalCost) DepthFirstSearch(Vertex firstVertex, Vertex lastVertex, string outputFilePath) {
			if (!adjacenceyList.ContainsKey(firstVertex) || !adjacencyList.ContainsKey(lastVertex))
				throw new ArgumentException("Start or end vertex not found in the graph.");


		}
	}
}	
