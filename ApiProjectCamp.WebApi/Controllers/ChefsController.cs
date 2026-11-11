using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ChefsController(ApiContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public IActionResult ListChef()
        {
            var chefs = _context.Chefs.ToList();
            return Ok(chefs);
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Chef created successfully");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var chefId = _context.Chefs.Find(id);
            if (chefId == null)
            {
                return NotFound("Chef not found");
            }
            else
            {
                _context.Chefs.Remove(chefId);
                _context.SaveChanges();
                return Ok("Chef deleted successfully");
            }
        }

        [HttpGet("GetChef")]
        public IActionResult GetChef(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound("Chef not found");
            }
            return Ok(chef);
        }

        [HttpPut]
        public IActionResult UpdateChef(int id, Chef chef)
        {
            var exChef = _context.Chefs.Find(id);
            if (exChef == null)
            {
                return NotFound("Chef not found");
            }
            else
            {
                exChef.NameSurname = chef.NameSurname;
                exChef.Title = chef.Title;
                exChef.ImageUrl = chef.ImageUrl;
                exChef.Description = chef.Description;
                _context.SaveChanges();
                return Ok("Chef updated successfully");
            }
        }



    }
}
