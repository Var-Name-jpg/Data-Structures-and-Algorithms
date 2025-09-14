namespace BattleshipFactory {
    /// <summary>
    /// Provides a method for retrieving descriptive information about an object.
    /// </summary>
    public interface IInformatic {
        /// <summary>
        /// Returns a string containing relevant information about the implementing object.
        /// </summary>
        /// <returns>A descriptive string.</returns>
        public string GetInfo();
    }
}
