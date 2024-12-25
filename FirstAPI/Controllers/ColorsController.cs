using FirstAPI.DTOs.Color;
using FirstAPI.Repositories.Interfaces;
using FirstAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColorsController : Controller
    {
        private readonly IColorService _service;

        public ColorsController(IColorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 20)
        {
            var colors = await _service.GetAll(page, take);
            return StatusCode(StatusCodes.Status200OK, colors);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            if(id < 1) return StatusCode(StatusCodes.Status400BadRequest);

            var colors = await _service.GetByIdAsync(id);

            if(colors is null) return StatusCode(StatusCodes.Status404NotFound);

            return StatusCode(StatusCodes.Status200OK, colors);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromForm]CreateColorDTO colorDTO)
        {
            await _service.CreateAsync(colorDTO);

            return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]

        public async Task<IActionResult> Update(int id, UpdateColorDTO colorDTO)
        {
            if(id < 1) return BadRequest();

            await _service.UpdateAsync(id, colorDTO);

            return NoContent();
        }
    }
}
