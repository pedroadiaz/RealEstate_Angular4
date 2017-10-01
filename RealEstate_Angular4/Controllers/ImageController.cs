using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate_Angular4.models;


namespace RealEstate_Angular4.Controllers
{
    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : Controller
    {
        private readonly realestateContext _context;

        public ImageController(realestateContext context)
        {
            _context = context;
        }

        // GET: api/House
        [HttpGet]
        public IEnumerable<Image> GetHouse()
        {
            return _context.Image;
        }

        [HttpGet("{HouseId}/ByHouseId")]
        public IEnumerable<Image> GetImagesByHouseId([FromRoute] int HouseId)
        {
            List<Image> images = new List<Image>();
            if (!ModelState.IsValid)
            {
                return images;
            }

            images = _context.Image.Where(m => m.Houseid == HouseId).ToList();

            return images;

        }

        [HttpPut("{id}")]
        public IActionResult PutImage([FromRoute] int id, [FromBody] Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.ImageId)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(image);
        }

        [HttpPost]
        public IActionResult PostImage([FromBody] Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Image.Add(image);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ImageExists(image.ImageId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetImage", new { id = image.ImageId }, image);
        }

        // DELETE: api/House/5
        [HttpDelete("{id}")]
        public IActionResult DeleteImage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = _context.Image.SingleOrDefault(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Image.Remove(image);
            _context.SaveChanges();

            return Ok();
        }


        private bool ImageExists(int id)
        {
            return _context.Image.Any(e => e.ImageId == id);
        }
    }

}