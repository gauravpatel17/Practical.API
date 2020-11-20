using Gaurav.Practical.API.IRepository;
using Gaurav.Practical.API.IService;
using Gaurav.Practical.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaurav.Practical.API.Service
{
    /// <summary>
    /// Color service
    /// </summary>
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        /// <summary>
        /// Color service
        /// </summary>
        /// <param name="colorRepository"></param>
        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        /// <summary>
        /// Get all color entries from color.json file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Color>> GetAllAsync(string filePath) => 
            await _colorRepository.GetAllAsync(filePath);

        /// <summary>
        /// Find color by name
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Color> FindAsync(string filePath, string name) =>
            await _colorRepository.FindAsync(filePath, name);

        /// <summary>
        /// Add specified color object to JSON file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public async Task<Color> AddAsync(string filePath, Color color) =>
            await _colorRepository.AddAsync(filePath, color);

        /// <summary>
        /// Update specified color object to JSON file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public async Task<Color> UpdateAsync(string filePath, Color color) =>
            await _colorRepository.UpdateAsync(filePath, color);

        /// <summary>
        /// Remove specified color objects from file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string filePath, string name) =>
            await _colorRepository.DeleteAsync(filePath, name);
    }
}
