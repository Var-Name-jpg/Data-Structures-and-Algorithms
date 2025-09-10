namespace BattleshipFactory {
    /// <summary>
    /// Represents a destroyer ship in the game, derived from the base <see cref="Ship"/> class.
    /// </summary>
    public class Destroyer : Ship {
        /// <summary>
        /// Initializes a new instance of the <see cref="Destroyer"/> class with a specified position, direction, and length.
        /// </summary>
        /// <param name="position">The starting coordinate of the destroyer.</param>
        /// <param name="direction">The direction the destroyer is facing.</param>
        /// <param name="length">The length of the destroyer.</param>
        public Destroyer(Coord2D position, DirectionType direction, int length) : base(position, direction, length) {}
    }
}

