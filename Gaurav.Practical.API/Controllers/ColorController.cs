using AutoMapper;
using Gaurav.Practical.API.Dto;
using Gaurav.Practical.API.IService;
using Gaurav.Practical.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gaurav.Practical.API.Controllers
{
    /// <summary>
    /// Color controller
    /// </summary>
    [Route("api/Colors")]
    //[ApiController]
    public class ColorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IColorService _colorService;
        private readonly string ContentRootPath;

        /// <summary>
        /// Color controller
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="environment"></param>
        /// <param name="colorService"></param>
        public ColorController(IMapper mapper, IWebHostEnvironment environment, 
            IColorService colorService)
        {
            _mapper = mapper;
            _environment = environment;
            _colorService = colorService;
            ContentRootPath = _environment.WebRootPath + @"\" + "Colors.json";
        }

        /// <summary>
        /// Get all color entries from color.json file
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var colors = await _colorService.GetAllAsync(ContentRootPath);
            return Ok(colors);
        }

        /// <summary>
        /// Find color by name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Find")]
        public async Task<IActionResult> FindAsync(string id)
        {
            var color = await _colorService.FindAsync(ContentRootPath, id);
            return Ok(color);
        }

        /// <summary>
        /// Add specified color object to JSON file
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(ColorDto colorDto)
        {
            var color = _mapper.Map<ColorDto, Color>(colorDto);
            await _colorService.AddAsync(ContentRootPath, color);
            return Ok(color);
        }

        /// <summary>
        /// Update specified color object to JSON file
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ColorDto colorDto)
        {
            var color = _mapper.Map<ColorDto, Color>(colorDto);
            await _colorService.UpdateAsync(ContentRootPath, color);
            return Ok(color);
        }

        /// <summary>
        /// Remove specified color objects from file
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _colorService.DeleteAsync(ContentRootPath, id);
            return Ok();
        }

        /// <summary>
        /// Raise error - to test exception handling
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("RaiseError")]
        public IActionResult RaiseError()
        {
            var names = new string[] { "Gaurav", "Patel" };
            return Ok(names[2]); // it will throw an exeption
        }
    }
}
