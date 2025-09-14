namespace BattleshipFactory {
    /// <summary>
    /// Represents a Submarine, a specific type of ship in the Battleship game.
    /// </summary>
    public class Submarine : Ship {
        /// <summary>
        /// Initializes a new instance of the <see cref="Submarine"/> class with the specified position, direction, and length.
        /// </summary>
        /// <param name="position">The starting coordinate of the submarine.</param>
        /// <param name="direction">The direction the submarine is facing.</param>
        /// <param name="length">The length of the submarine.</param>
        public Submarine(Coord2D position, DirectionType direction, int length) : base(position, direction, length) {}
    }
}
