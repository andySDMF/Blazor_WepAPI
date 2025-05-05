using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;
        public PhotoController(ApplicationDBContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public IActionResult GetPhotos()
        {
            var photos = dbContext.Photos.Include(c => c.Category).ToList();
            return Ok(photos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPhoto(int id)
        {
            var photos = dbContext.Photos.Include(c => c.Category).ToList();
            var evt = photos.FirstOrDefault(c => c.Id == id);

            if (evt == null)
            {
                return NotFound();
            }

            return Ok(evt);
        }

        [HttpPost]
        public IActionResult CreatePhoto(PhotoDto photoDto)
        {
            var category = dbContext.PhotoCategories.Find(photoDto.CategoryId);

            if (category == null) 
            {
                return BadRequest($"400");
            }

            var img = new Photo()
            {
                Title = photoDto.Title,
                Description = photoDto.Description,
                ImageUrl = photoDto.ImageUrl,
                CreatedAt = DateTime.Now,
                CategoryId = photoDto.CategoryId,
                Category = category
            };

            dbContext.Photos.Add(img);
            dbContext.SaveChanges();

            return Ok(img);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePhoto(int id, PhotoDto photoDto)
        {
            var category = dbContext.PhotoCategories.Find(photoDto.CategoryId);

            if (category == null)
            {
                return BadRequest($"400");
            }

            var img = dbContext.Photos.Find(id);

            if (img == null)
            {
                return NotFound();
            }

            img.Title = photoDto.Title;
            img.Description = photoDto.Description;
            img.ImageUrl = photoDto.ImageUrl;
            img.CategoryId = photoDto.CategoryId;
            img.Category = category;

            dbContext.SaveChanges();

            return Ok(img);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePhoto(int id)
        {
            var img = dbContext.Photos.Find(id);

            if (img == null)
            {
                return NotFound();
            }

            dbContext.Photos.Remove(img);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
