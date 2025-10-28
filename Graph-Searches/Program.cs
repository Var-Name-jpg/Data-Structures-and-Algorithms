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

			Vertex startVert1k = new Vertex("scarlet kite");
			Vertex lastVert1k = new Vertex("glossy crane");

			Vertex startVert10k = new Vertex("verdant buffalo");
			Vertex lastVert10k = new Vertex("vivid horse");

			graph100.DepthFirstSearch(startVert100, lastVert100, "output-files/DFS-Search-100.txt");
			graph1k.DepthFirstSearch(startVert1k, lastVert1k, "output-files/DFS-Search-1k.txt");
			graph10k.DepthFirstSearch(startVert10k, lastVert10k, "output-files/DFS-Search-10k.txt");
			
			graph100.BreadthFirstSearch(startVert100, lastVert100, "output-files/BFS-Search-100.txt");
			graph1k.BreadthFirstSearch(startVert1k, lastVert1k, "output-files/BFS-Search-1k.txt");
			graph10k.BreadthFirstSearch(startVert10k, lastVert10k, "output-files/BFS-Search-10k.txt");
			
			graph100.Dijkstras(startVert100, lastVert100, "output-files/Dijkstras-Search-100.txt");
			graph1k.Dijkstras(startVert1k, lastVert1k, "output-files/Dijkstras-Search-1k.txt");
			graph10k.Dijkstras(startVert10k, lastVert10k, "output-files/Dijkstras-Search-10k.txt");
		}
	}
}
