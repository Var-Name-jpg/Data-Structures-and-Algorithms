namespace BattleshipFactory {
    /// <summary>
    /// Represents a battleship in the game, derived from the base <see cref=Ship/> class.
    /// </summary>
    public class Battleship : Ship {
        /// <summary>
        /// Initializes a new instance of the <see cref=Battleship/> class with a specified position, direction, and length.
        /// </summary>
        /// <param name=position>The starting coordinate of the battleship.</param>
        /// <param name=direction>The direction the battleship is facing.</param>
        /// <param name=length>The length of the battleship.</param>
        public Battleship(Coord2D position, DirectionType direction, int length) : base(position, direction, length) {}
    }
}
