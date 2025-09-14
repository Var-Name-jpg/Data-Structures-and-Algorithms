using System;
using System.Collections.Generic;

namespace BattleshipFactory {
    /// <summary>
    /// Abstract base class representing a ship in the Battleship game.
    /// Implements health tracking and informational reporting.
    /// </summary>
    public abstract class Ship : IHealth, IInformatic {
        /// <summary>
        /// Gets or sets the starting position of the ship.
        /// </summary>
        public Coord2D Position { get; set; }

        /// <summary>
        /// Gets or sets the direction the ship is facing.
        /// </summary>
        public DirectionType Direction { get; set; }

        /// <summary>
        /// Gets or sets the current length (health) of the ship.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets the list of coordinates occupied by the ship.
        /// </summary>
        public List<Coord2D> Points { get; set; }

        /// <summary>
        /// Gets or sets the list of coordinates where the ship has been damaged.
        /// </summary>
        public List<Coord2D> DamagedPoints { get; set; }

        /// <summary>
        /// Factory used to generate ship points.
        /// </summary>
        public ShipFactory shipFact = new ShipFactory();

        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class.
        /// </summary>
        /// <param name="position">Starting coordinate of the ship.</param>
        /// <param name="direction">Direction the ship is facing.</param>
        /// <param name="length">Length of the ship.</param>
        public Ship(Coord2D position, DirectionType direction, int length) {
            Position = position;
            Direction = direction;
            Length = length;
            Points = shipFact.GenerateShipPoints(position, direction, length);
            DamagedPoints = new List<Coord2D>();
        }

        /// <summary>
        /// Returns the type of ship as a string based on its class.
        /// </summary>
        /// <returns>Ship type name.</returns>
        public string ShipType() => this switch {
            Carrier => "Carrier",
            Battleship => "Battleship",
            Destroyer => "Destroyer",
            Submarine => "Submarine",
            PatrolBoat => "Patrol Boat",
            _ => "Internal Error: Ship not identified"
        };

        // IHealth Methods

        /// <summary>
        /// Gets the maximum health of the ship.
        /// </summary>
        /// <returns>Total number of points the ship occupies.</returns>
        public int GetMaxHealth() {
            return Points.Count;
        }

        /// <summary>
        /// Gets the current health of the ship.
        /// </summary>
        /// <returns>Number of undamaged points.</returns>
        public int GetCurrentHealth() {
            return (Points.Count - DamagedPoints.Count);
        }

        /// <summary>
        /// Determines whether the ship is dead (length is zero or less).
        /// </summary>
        /// <returns><c>true</c> if the ship is dead; otherwise, <c>false</c>.</returns>
        public bool IsDead() {
            if (Length <= 0) return true;
            return false;
        }

        // IInformatic Methods

        /// <summary>
        /// Returns a string containing information about the ship.
        /// </summary>
        /// <returns>Formatted string with ship type, position, direction, and health status.</returns>
        public string GetInfo() {
            string info = $"{ShipType()} (Length {Length}) at ({Position.X},{Position.Y}) {Direction.ToString()}";
            info += $" | HP: {GetCurrentHealth()}/{GetMaxHealth()} | ";
            info += IsDead() ? "Sunk" : "Alive";

            return info;
        }

        /// <summary>
        /// Checks whether the given coordinate hits the ship.
        /// </summary>
        /// <param name="point">The coordinate to check.</param>
        /// <returns><c>true</c> if the point is part of the ship; otherwise, <c>false</c>.</returns>
        public bool CheckIfHit(Coord2D point) {
            return Points.Contains(point);
        }

        /// <summary>
        /// Applies damage to the ship at the specified coordinate if it hasn't already been hit.
        /// </summary>
        /// <param name="point">The coordinate to damage.</param>
        /// <returns><c>true</c> if the damage was applied; <c>false</c> if it was already damaged or missed.</returns>
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
