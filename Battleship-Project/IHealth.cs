namespace BattleshipFactory {
	public interface IHealth {
		public int GetMaxHealth();
		public int GetCurrentHealth();
		public bool IsDead();
	}
}
