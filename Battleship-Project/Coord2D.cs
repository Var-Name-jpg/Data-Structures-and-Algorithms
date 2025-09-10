using System;
using System.Collections.Generic;

namespace BattleshipFactory {
    /// <summary>
    /// Represents a two-dimensional coordinate with X and Y values.
    /// </summary>
    public class Coord2D {
        /// <summary>
        /// Gets or sets the X component of the coordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y component of the coordinate.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coord2D"/> class with specified X and Y values.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Coord2D(int x, int y) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns a string representation of the coordinate in the format "(X,Y)".
        /// </summary>
        /// <returns>A string representing the coordinate.</returns>
        public override string ToString() {
            return $"({X},{Y})";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current coordinate.
        /// </summary>
        /// <param name="obj">The object to compare with the current coordinate.</param>
        /// <returns><c>true</c> if the specified object is a <see cref="Coord2D"/> with the same X and Y; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) {
            if (obj is Coord2D other) {
                return this.X == other.X && this.Y == other.Y;
            }
            return false;
        }

        /// <summary>
        /// Returns a hash code for the coordinate.
        /// </summary>
        /// <returns>A hash code based on the X and Y values.</returns>
        public override int GetHashCode() {
            return HashCode.Combine(X, Y);
        }

        /// <summary>
        /// Attempts to parse a string into a <see cref="Coord2D"/> object.
        /// </summary>
        /// <param name="str">The string to parse, expected in the format "(X,Y)".</param>
        /// <param name="coord">When this method returns, contains the parsed <see cref="Coord2D"/> if successful; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if parsing was successful and the coordinates are within bounds (0–9); otherwise, <c>false</c>.</returns>
        public bool TryParse(string str, out Coord2D coord) {
            coord = default;
            str = str.Trim();

            if (str.StartsWith("(") && str.EndsWith(")")) {
                str = str.Substring(1, str.Length - 2);
                var parts = str.Split(',');

                if (parts.Length == 2 &&
                        int.TryParse(parts[0].Trim(), out int xVal) &&
                        int.TryParse(parts[1].Trim(), out int yVal)) {
                    if (xVal < 0 || xVal > 9) { return false; }
                    if (yVal < 0 || yVal > 9) { return false; }

                    coord = new Coord2D(xVal, yVal);
                    return true;
                }
            }
            return false;
        }
    }
}

