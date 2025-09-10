namespace BattleshipFactory {
    /// <summary>
    /// Represents a carrier ship in the game, derived from the base <see cref=Ship/> class.
    /// </summary>
    public class Carrier : Ship {
        /// <summary>
        /// Initializes a new instance of the <see cref=Carrier/> class with a specified position, direction, and length.
        /// </summary>
        /// <param name=position>The starting coordinate of the carrier.</param>
        /// <param name=direction>The direction the carrier is facing.</param>
        /// <param name=length>The length of the carrier.</param>
        public Carrier(Coord2D position, DirectionType direction, int length) : base(position, direction, length) {}
    }
}
