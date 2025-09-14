namespace BattleshipFactory {
    /// <summary>
    /// Represents the core game logic for managing a fleet of ships in the Battleship game.
    /// </summary>
    public class Game {
        /// <summary>
        /// Gets or sets the list of ships currently in play.
        /// </summary>
        public List<Ship> Fleet { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class with the specified fleet.
        /// </summary>
        /// <param name="fleet">The list of ships to be used in the game.</param>
        public Game(List<Ship> fleet) {
            Fleet = fleet;
        }

        /// <summary>
        /// Determines whether all ships in the fleet have been sunk.
        /// </summary>
        /// <returns><c>true</c> if no ships remain in the fleet; otherwise, <c>false</c>.</returns>
        public bool AllSunk() {
            return !Fleet.Any();
        }
    }
}
