namespace ComputerSystem.Core
{ 
    /// <summary>
    /// The main printed circuit board
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Load values from the RAM
        /// </summary>
        /// <returns>Returns the value given from the RAM</returns>
        int LoadRamValue();

        /// <summary>
        /// Save values to the RAM 
        /// </summary>
        /// <param name="value">Value to be saved in the RAM</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draw on the video card
        /// </summary>
        /// <param name="data">Data that will be drawn on the video card</param>
        void DrawOnVideoCard(string data);
    }
}
