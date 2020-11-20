using Gaurav.Practical.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaurav.Practical.API.IService
{
    /// <summary>
    /// Color service interface
    /// </summary>
    public interface IColorService
    {
        /// <summary>
        /// Get all color entries from color.json file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<IEnumerable<Color>> GetAllAsync(string filePath);

        /// <summary>
        /// Find color by name
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Color> FindAsync(string filePath, string name);

        /// <summary>
        /// Add specified color object to JSON file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        Task<Color> AddAsync(string filePath, Color color);

        /// <summary>
        /// Update specified color object to JSON file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        Task<Color> UpdateAsync(string filePath, Color color);

        /// <summary>
        /// Remove specified color objects from file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task DeleteAsync(string filePath, string name);
    }
}
