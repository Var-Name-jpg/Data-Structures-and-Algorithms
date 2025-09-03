using System;
using System.Collections.Generic;
using System.IO;

namespace BattleshipFactory {
	public class ShipFactory {
		public Ship ParseShipString(string shipString) {
			char[] delimiters = new char[] {',', ' '};
			string[] tempVals = shipString.Split(delimiters, StringSplitOperations.RemoveEmptyEnteries);
			
			// Verification
			string[] validShipTypes = new string[] {"carrier", "battleship", "destroyer", "submarine"  };
			string[] validDirectionTypes = new string[] { "h", "horizontal", "v", "vertical" };
			
			// Data
			string shipType = string.Empty;
			DirectionType direction;

			for (int i = 0; i < tempVals.Length; i++) {

				// Check Ship Type is Valid
				if (String.IsNullOrEmpty(shipType)) {

					// Check patrol boat
					if (tempVals[i].ToLower() == "patrol" && tempVals[i+1].ToLower() == "boat") {
				       		tempVals[i] = "patrolboat";
						tempVals.RemoveAt(1);
						shipType = "patrolboat";

					} else if (validShipTypes.Contains(tempVals[i])) {
						shipType = tempVals[i];

					} else {
					       	throw new Exception("Cannot Parse Ship Type.. Moving On");
				       	}
				}

				// Check if direction is valid
			}
		}

		public List<Ship> ParseShipFile(string shipFile) {
			List<Ship> ships = new List<Ship>();

			if (!File.Exists(shipFile)) {
				Console.WriteLine($"File not found ({shipFile})");
				return null;
			}

			string[] lines = File.ReadAllLines(shipFile);
			foreach (string line in lines) {
				try {
					ships.Add(ParseShipString(line));
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
				}
			}

			return ships;
		}

		public List<Coord2D> GenerateShipPoints(Coord2D start, DirectionType direction, int length) {
			var points = new List<Coord2D>();
			for (int i = 0; i < length; i++) {
				if (direction == DirectionType.Horizontal) {
					points.Add(new Coord2D(start.X + i, start.Y));
				} else {
					points.Add(new Coord2D(start.X, start.Y + i));
				}
			}
			return points;
		}
	}
}
