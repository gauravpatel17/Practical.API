namespace Gaurav.Practical.API.Dto
{
    /// <summary>
    /// DTO for holding color properties 
    /// </summary>
    public class ColorDto
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
        public ColorCodeDto Code { get; set; }
    }

    /// <summary>
    /// DTO for holding color code properties 
    /// </summary>
    public class ColorCodeDto
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
