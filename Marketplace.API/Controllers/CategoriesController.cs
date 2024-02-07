using AutoMapper;
using Marketplace.API.Models;
using Marketplace.Core.DTOs;
using Marketplace.Core.Entities;
using Marketplace.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //וזאת כיון שהיא נשלפת בכל מקרה שהרי גם היא בטבלת קטגוריות. (כלומר, זה קורה כשיש קשר לאותה טבלה עצמה.) Include נשים לב שבמקרה זה קטגוריית האב תיכלל בשליפה למרות שאין
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryPostModel model)
        {
            //check if parentId exists
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(model));
            return Ok(_mapper.Map<CategoryDto>(newCategory));
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryPostModel model)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            _mapper.Map(model, category);//להסביר!!
            await _categoryService.UpdateAsync(category);
            category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(category));

        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
