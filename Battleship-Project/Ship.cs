using System;
using System.Collections.Generic;

namespace BattleshipFactory {
	public abstract class Ship : IHealth, IInformatic {
		public Coord2D Position { get; set; }
		public DirectionType Direction { get; set; }
		public int Length { get; set; }
		public List<Coord2D> Points { get; set; }
		public List<Coord2D> DamagedPoints { get; set; }

		public ShipFactory shipFact = new ShipFactory();

		public Ship(Coord2D position, DirectionType direction, int length) {
			Position = position;
			Direction = direction;
			Length = length;
			Points = shipFact.GenerateShipPoints(position, direction, length);
			DamagedPoints = new List<Coord2D>();
		}

		// Get Ship Type based on length
		public string ShipType() => this switch {
			Carrier => "Carrier",
			Battleship => "Battleship",
			Destroyer => "Destroyer",
			Submarine => "Submarine",
			PatrolBoat => "Patrol Boat",
			_ => "Internal Error: Ship not identified"
		};


		// IHealth Methods
		public int GetMaxHealth() {
			return Points.Count;
		}

		public int GetCurrentHealth() {
			return (Points.Count - DamagedPoints.Count);
		}

		public bool IsDead() {
			if (Length <= 0) return true;
			return false;
		}

		// IInformatic Methods
		public string GetInfo() {
			string info = $"{ShipType()} (Length {Length}) at ({Position.X},{Position.Y}) {Direction.ToString()}";
			info += $" | HP: {GetCurrentHealth()}/{GetMaxHealth()} | ";
			info += IsDead() ? "Sunk" : "Alive";

			return info;
		}

		public bool CheckIfHit(Coord2D point) {
			return Points.Contains(point);
		}

		public bool TakeDamage(Coord2D point) {
			if (CheckIfHit(point)) {
				foreach (Coord2D pt in this.DamagedPoints) {
					if (pt.Equals(point)) {
						return false;
					}
				}
				this.DamagedPoints.Add(point);
				this.Length -= 1;

				if (this.Length < 0) { this.Length = 0; }

				Console.WriteLine($"Hit! You hit a {ShipType()}!");
				return true;
			}
			return false;
		}
	}
}
