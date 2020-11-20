namespace Gaurav.Practical.API.Model
{
    /// <summary>
    /// Domain model for holding color properties 
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public ColorCode Code { get; set; }
    }

    /// <summary>
    /// Domain model for holding color code properties 
    /// </summary>
    public class ColorCode
    {
        /// <summary>
        /// RGBA
        /// </summary>
        public int[] RGBA { get; set; }
        /// <summary>
        /// Hex
        /// </summary>
        public string Hex { get; set; }
    }
}
