using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        public CategoriesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListCategory()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Category created successfully");
        }        

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var categoryId = _context.Categories.Find(id);
            if (categoryId == null)
            {
                return NotFound("Category not found");
            }
            _context.Categories.Remove(categoryId);
            _context.SaveChanges();
            return Ok("Category deleted successfully"); 
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }

        [HttpPut]
        public IActionResult UpdateCategory(int id, Category category)
        {
            var existingCategory = _context.Categories.Find(id);
            if (existingCategory == null)
            {
                return NotFound("Category not found");
            }
            existingCategory.CategoryName = category.CategoryName;
            _context.SaveChanges();
            return Ok("Category updated successfully");
        }

    }
}
