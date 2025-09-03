using System;
using System.Collections.Generic;

namespace BattleshipFactory {
	public class Program {
		public static void Main(String[] args) {
			bool fileProvided = false;
			string filePath = string.Empty;

			// Check for command line arguments
			if (args.Length >= 2) {
				if (args[0] == "-f") {
					filePath = args[1];
					fileProvided = true;
				}
			}


			ShipFactory shipFact = new ShipFactory();
			List<Ship> squadron = shipFact.ParseShipFile(filePath);
			
			foreach (Ship ship in squadron) {
				ship.Points = shipFact.GenerateShipPoints(ship.Position, ship.Direction, ship.Length);
			}
		}
	}
}
