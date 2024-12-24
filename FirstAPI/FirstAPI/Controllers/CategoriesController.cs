using FirstAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public async Task<IActionResult> Get(int page = 1, int take = 2)
        {
            var categories = await _repository.GetAll(skip:(page-1)*take, take:take).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, categories);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1) return BadRequest();

            Category category = await _repository.GetByIdAsync(id);

            if (category == null) return NotFound();

            return StatusCode(StatusCodes.Status200OK, category);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromForm]CreateCategoryDTO categoryDTO)
        {
            Category category = new Category()
            {
                Name = categoryDTO.Name
            };

            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();

            Category category = await _repository.GetByIdAsync(id);

            if (category == null) return NotFound();

           _repository.Delete(category);

            await _repository.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, string name)
        {

            if (id < 1) return BadRequest();

            Category existed = await _repository.GetByIdAsync(id);

            if (existed == null) return NotFound();

            existed.Name = name;

             _repository.Update(existed);

            await _repository.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
