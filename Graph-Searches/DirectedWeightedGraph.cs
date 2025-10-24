using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

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
		public override bool Equals(object obj) {
			return obj is Vertex other && Id == other.Id;
		}
		public override int GetHashCode() {
			return Id.GetHashCode();
		}
	}

	public partial class DirectedWeightedGraph {
		public Dictionary< Vertex, List<Edge> > adjacencyList = new Dictionary< Vertex, List<Edge> >();

		public DirectedWeightedGraph(string filePath) {
			foreach (string line in File.ReadLines(filePath)) {
				List<string> tempData = line.Split(',').ToList();


				Vertex newVertex = new Vertex(tempData[0]);
				Vertex destination = new Vertex(tempData[1]);
				int weight = int.Parse(tempData[2]);

				AddVertex(newVertex);
				AddEdge(newVertex, new Edge(destination, weight));
			}
		}
	

		public void AddVertex(Vertex vertex) {
			foreach (Vertex node in adjacencyList.Keys) {
				if (vertex.Equals(node))
					return;
			}

			adjacencyList.Add(vertex, new List<Edge>());
		}

		public void AddEdge(Vertex source, Edge connection) {
			if (!adjacencyList.ContainsKey(connection.Destination))
				AddVertex(connection.Destination);

			adjacencyList[source].Add(connection);
		}

		public List<Edge> GetNeighbors(Vertex vertex) {
			return adjacencyList.ContainsKey(vertex) ? adjacencyList[vertex] : new List<Edge>();
		}

		public List<Vertex> GetVerticies() {
			List<Vertex> verticies = new List<Vertex>();

			foreach (Vertex vertex in adjacencyList.Keys) {
				if (!verticies.Contains(vertex))
					verticies.Add(vertex);
			}

			return verticies;
		}

		public void PrintGraph() {
			string printMe = "";
			foreach (Vertex vertex in adjacencyList.Keys) {
				printMe += $"{vertex.Id} -> ";
				var temp = new List<string>();

				foreach (Edge edge in adjacencyList[vertex]) {
					temp.Add($"[{edge.Destination.Id},{edge.Weight}]");
				}

				printMe += string.Join(',', temp);
				printMe += "\n";
			}

			Console.WriteLine(printMe);
		}
	}
}
