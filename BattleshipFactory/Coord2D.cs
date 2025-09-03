using System;
using System.Collections.Generic;

namespace BattleshipFactory {
	public class Coord2D {
		public int X { get; set; }
		public int Y { get; set; }

		public Coord2D(int x, int y) {
			X = x;
			Y = y;
		}

		public override string ToString() {
			return $"({X},{Y})";
		}

		public override bool Equals(object obj) {
			if (obj is Coord2D other) {
				return this.X == other.X && this.Y == other.Y;
			}
			return false;
		}

		public override int GetHashCode() {
			return HashCode.Combine(X, Y);
		}

		public bool TryParse(string str, out Coord2D coord) {
			coord = default;
			str = str.Trim();

			if (str.StartsWith("(") && str.EndsWith(")")) {
				str = str.Substring(1, str.Length - 2);
				var parts = str.Split(',');

				if (parts.Length == 2 &&
						int.TryParse(parts[0].Trim(), out int xVal) &&
						int.TryParse(parts[1].Trim(), out int yVal)) {
					coord = new Coord2D(xVal, yVal);
					return true;
				}
			}
			return false;
		}
	}
}
