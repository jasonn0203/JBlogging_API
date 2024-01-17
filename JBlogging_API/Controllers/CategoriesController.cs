using JBlogging_API.DTOs.Category;
using JBlogging_API.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JBlogging_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IGeneralRepository<CategoryDTO> _repository;

        public CategoriesController(IGeneralRepository<CategoryDTO> repository)
        {
            _repository = repository;
        }

        // GET: api/<CategoriesController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var categoryList = await _repository.GetAllAsync();
            return Ok(categoryList);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var category = await _repository.GetByIDAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var category = await _repository.GetByNameAsync(name);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<CategoriesController>
        [HttpPost("AddCategory")]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                await _repository.AddAsync(categoryDTO);

                return CreatedAtAction(nameof(GetByName), new { cateName = categoryDTO.CateName }, categoryDTO);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _repository.GetByIDAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();

        }
    }
}
