namespace BattleshipFactory {
    /// <summary>
    /// Represents a Patrol Boat, a specific type of ship in the Battleship game.
    /// </summary>
    public class PatrolBoat : Ship {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatrolBoat"/> class with the specified position, direction, and length.
        /// </summary>
        /// <param name="position">The starting coordinate of the patrol boat.</param>
        /// <param name="direction">The direction the patrol boat is facing.</param>
        /// <param name="length">The length of the patrol boat.</param>
        public PatrolBoat(Coord2D position, DirectionType direction, int length) : base(position, direction, length) {}
    }
}
