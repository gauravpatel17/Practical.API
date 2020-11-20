using Gaurav.Practical.API.IRepository;
using Gaurav.Practical.API.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaurav.Practical.API.Repository
{
    /// <summary>
    /// Color repository
    /// </summary>
    public class ColorRepository : IColorRepository
    {
        /// <summary>
        /// Color repository
        /// </summary>
        public ColorRepository() // we can inject database connectivity here for real world application 
        {

        }

        /// <summary>
        /// Get all color entries from color.json file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Color>> GetAllAsync(string filePath)
        {
            var fileContent = await File.ReadAllTextAsync(filePath); // read all text of file as a string 
            var colors = JsonConvert.DeserializeObject<IEnumerable<Color>>(fileContent); // convert file content to domain objects 
            return colors;
        }

        /// <summary>
        /// Find color by name
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Color> FindAsync(string filePath, string name)
        {
            var colors = await GetAllAsync(filePath);
            return colors.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Add specified color object to JSON file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public async Task<Color> AddAsync(string filePath, Color color)
        {
            var colors = (await GetAllAsync(filePath)).ToList();
            colors.Add(color); // add specified color object to existing color list
            var convertedJson = JsonConvert.SerializeObject(colors, Formatting.Indented);
            await File.WriteAllTextAsync(filePath, convertedJson);
            return color;
        }

        /// <summary>
        /// Update specified color object to JSON file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public async Task<Color> UpdateAsync(string filePath, Color color)
        {
            var colors = (await GetAllAsync(filePath)).ToList();
            var colorToUpdateIndex = colors.FindIndex(x => x.Name == color.Name);
            colors[colorToUpdateIndex] = color; // update specified color object to matching position in JSON file
            var convertedJson = JsonConvert.SerializeObject(colors, Formatting.Indented);
            await File.WriteAllTextAsync(filePath, convertedJson);
            return color;
        }

        /// <summary>
        /// Remove specified color objects from file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string filePath, string name)
        {
            var colors = (await GetAllAsync(filePath)).ToList();
            colors.RemoveAll(x => x.Name == name); // remove all matching entries, remove all color entries that are matching with received name
            var convertedJson = JsonConvert.SerializeObject(colors, Formatting.Indented);
            await File.WriteAllTextAsync(filePath, convertedJson);
        }
    }
}
