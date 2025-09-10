namespace BattleshipFactory {
	public class Game {
		public List<Ship> Fleet { get; set; }

		public Game(List<Ship> fleet) {
			Fleet = fleet;
		}

		public bool AllSunk() {
			return !Fleet.Any();
		}
	}
}
