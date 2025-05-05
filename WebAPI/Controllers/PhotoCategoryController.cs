using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoCategoryController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;
        public PhotoCategoryController(ApplicationDBContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public IActionResult GetPhotoCategories()
        {
            var categories = dbContext.PhotoCategories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetPhotoCategory(int id)
        {
            var category = dbContext.PhotoCategories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreatePhotoCategory(PhotoCategoryDto categoryDto)
        {
            var exists = dbContext.PhotoCategories.FirstOrDefault(c => c.Name.Equals(categoryDto.Name));

            if (exists != null)
            {
                return BadRequest($"400");
            }

            var category = new PhotoCategory()
            {
                Name = categoryDto.Name
            };

            dbContext.PhotoCategories.Add(category);
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCatgery(int id, PhotoCategoryDto categoryDto)
        {
            var exists = dbContext.PhotoCategories.FirstOrDefault(c => c.Name.Equals(categoryDto.Name));

            if (exists != null)
            {
                return BadRequest($"400");
            }

            var category = dbContext.PhotoCategories.Find(id);

            if(category == null)
            {
                return NotFound();
            }

            category.Name = categoryDto.Name;
            dbContext.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            //need to check if any photo has this catagory
            //if true then cannot delete

            var category = dbContext.PhotoCategories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            dbContext.PhotoCategories.Remove(category);
            dbContext.SaveChanges();

            return Ok($"{category.Name} deleted");
        }
    }
}
