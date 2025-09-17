namespace BattleshipFactory {
    /// <summary>
    /// Represents a health system interface for entities that can take damage and potentially die.
    /// </summary>
    public interface IHealth {
        /// <summary>
        /// Gets the maximum health value of the entity.
        /// </summary>
        /// <returns>The maximum health as an integer.</returns>
        public int GetMaxHealth();

        /// <summary>
        /// Gets the current health value of the entity.
        /// </summary>
        /// <returns>The current health as an integer.</returns>
        public int GetCurrentHealth();

        /// <summary>
        /// Determines whether the entity is considered dead.
        /// </summary>
        /// <returns>True if the entity's health is zero or below; otherwise, false.</returns>
        public bool IsDead();
    }
}
