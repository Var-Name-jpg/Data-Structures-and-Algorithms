using System;
using System.Collections.Generic;
using System.IO;

namespace BattleshipFactory {
	public class ShipFactory {
		public Ship ParseShipString(string shipString, List<Ship> activeShips) {
			char[] delimiters = new char[] {',', ' '};
			List<string> tempVals = shipString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();

			// Verification
			List<string> validShipTypes = new List<string> {"carrier", "battleship", "destroyer", "submarine"  };
			List<string> validDirectionTypes = new List<string> { "h", "horizontal", "v", "vertical" };
			
			// Data
			string shipType = string.Empty;
			DirectionType direction = DirectionType.None;
			int length = 0;
			int startX = 0;
			int startY = 0;

			// Check Ship Type is Valid
			// Check patrol boat
			if (tempVals[0].ToLower() == "patrol" && tempVals[1].ToLower() == "boat") {
				tempVals[0] = "patrolboat";
				tempVals.RemoveAt(1);
				shipType = "patrolboat";

			} else if (validShipTypes.Contains(tempVals[0].ToLower())) {
				shipType = tempVals[0].ToLower();

			} else {
		 		throw new Exception("Cannot Parse Ship Type.. Moving On");
			}

			// Check Length is Valid
			int tempLength = int.Parse(tempVals[1]);

			switch (shipType) {
				case "carrier":
					if (tempLength == 5) { length = 5; }
					else { throw new Exception("Incorrect length for Carrier ship class.. Moving On.."); }
					break;
				case "battleship":
					if (tempLength == 4) { length = 4; }
					else { throw new Exception("Incorrect length for Battleship ship class.. Moving On.."); }
					break;
				case "destroyer":
					if (tempLength == 3) { length = 3; }
					else { throw new Exception("Incorrect length for Destoryer ship class.. Moving On.."); }
					break;
				case "submarine":
					if (tempLength == 3) { length = 3; }	
					else { throw new Exception("Incorrect length for Submarine ship class.. Moving On.."); }
					break;
				case "patrolboat":
					if (tempLength == 2) { length = 2; }
					else { throw new Exception("Incorrect length for Patrol Boat ship class.. Moving On.."); }
					break;
				default:
					throw new Exception("Internal Error. Please reload the application.");
			}

			// Check Direction is Valid
			if (validDirectionTypes.Contains(tempVals[2])) {
				switch (tempVals[2].ToLower()) {
					case "v":
						direction = DirectionType.Vertical;
						break;
					case "vertical":
						direction = DirectionType.Vertical;
						break;
					case "h":
						direction = DirectionType.Horizontal;
						break;
					case "horizontal":
						direction = DirectionType.Horizontal;
						break;
				}
			} else {
				throw new Exception("Cannot Parse Direction.. Moving On");
			}

			// Check the starting points
			if (int.Parse(tempVals[3]) < 0 || int.Parse(tempVals[3]) > 9) {
				throw new Exception("Cannot Parse.. Point not on board.. Moving On");
			} else if (int.Parse(tempVals[4]) < 0 || int.Parse(tempVals[4]) > 9) {
				throw new Exception("Cannot Parse.. Point not on board.. Moving On");
			}
			else if (int.Parse((tempVals[3]) + length) > 9 || int.Parse((tempVals[4]) + length) > 9) {
				throw new Exception("Cannot Parse.. Too Close to Edge.. Moving On");
			} else {
				startX = int.Parse(tempVals[3]);
				startY = int.Parse(tempVals[4]);
			}

			// Make the ship coords and test them against other ships to prevent overlaping
			Coord2D shipCoord = new Coord2D(startX, startY);

			foreach (Ship ship in activeShips) {
				for (int i = 0; i < ship.Points.Count; i++) {
					if (shipCoord.Equals(ship.Points[i])) {
						throw new Exception("Cannot Make Ship.. Overlaping Error.. Moving On");
					}
				}
			}

			switch (shipType) {
				case "carrier":
					return new Carrier(shipCoord, direction, length);
				case "battleship":
					return new Battleship(shipCoord, direction, length);
				case "destroyer":
					return new Destroyer(shipCoord, direction, length);
				case "submarine":
					return new Submarine(shipCoord, direction, length);
				case "patrolboat":
					return new PatrolBoat(shipCoord, direction, length);
			}

			return null;
		}

		public List<Ship> ParseShipFile(string shipFile) {
			List<Ship> ships = new List<Ship>();

			if (!File.Exists(shipFile)) {
				Console.WriteLine($"File not found ({shipFile})");
				return null;
			}

			string[] lines = File.ReadAllLines(shipFile);
			foreach (string line in lines) {
				if (line.StartsWith('#')) { continue; }
				try {
					ships.Add(ParseShipString(line, ships));
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
				}
			}

			return ships;
		}

		public List<Coord2D> GenerateShipPoints(Coord2D start, DirectionType direction, int length) {
			List<Coord2D> points = new List<Coord2D>();
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
