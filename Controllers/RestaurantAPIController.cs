using cesay.QR.API.Data;
using cesay.QR.API.Models;
using cesay.QR.API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cesay.QR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RestaurantAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<RestaurantDTO>> GetRestaurants()
        {
            return Ok(_context.Restaurants.ToList());
        }

        [HttpGet("{id:int}", Name = "GetRestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RestaurantDTO> GetRestaurant(int id)
        {
            if ( id == 0)
            {
                return BadRequest();
            }
            var restaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);
            if (restaurant == null )
            {
                return NotFound();
            }            
            return Ok(restaurant);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RestaurantDTO> CreateRestaurant([FromBody]RestaurantDTO restaurant)
        {
            if (_context.Restaurants.FirstOrDefault(x=> x.Name.ToLower()==restaurant.Name.ToLower())!= null)
            {
                ModelState.AddModelError("CustomError", "Restaurant already exist!");
                return BadRequest(ModelState);
            }

            if (restaurant == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            if (restaurant.Id > 0 )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Restaurant resto = new Restaurant()
            {
                Name = restaurant.Name,
                Description = restaurant.Description,
                Id = restaurant.Id,
                ImageUrl = restaurant.ImageUrl,
                Latitude = restaurant.Latitude,
                Longitude = restaurant.Longitude,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
            _context.Restaurants.Add(resto);
            _context.SaveChanges();
            return CreatedAtRoute("GetRestaurant", new {id = restaurant.Id }, restaurant);
        }

        [HttpDelete("{id:int}", Name = "DeleteRestaurant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteRestaurant(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var restaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpPut("{id:int}", Name = "UpdateRestaurant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateRestaurant(int id, [FromBody] RestaurantDTO restaurantDTO)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var restaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            restaurant.Name = restaurantDTO.Name;
            restaurant.Description = restaurantDTO.Description;
            restaurant.Longitude = restaurantDTO.Longitude;
            restaurant.Latitude = restaurantDTO.Latitude;
            restaurant.Rate = restaurantDTO.Rate;
            restaurant.ImageUrl = restaurantDTO.ImageUrl;
            restaurant.UpdatedDate = DateTime.UtcNow;
            _context.Restaurants.Update(restaurant);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpPatch("{id:int}", Name = "UpdatePartialRestaurant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePartialRestaurant(int id, JsonPatchDocument<RestaurantDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var restaurant = _context.Restaurants.AsNoTracking().FirstOrDefault(x => x.Id ==id);

            RestaurantDTO restoDTO = new RestaurantDTO()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Longitude = restaurant.Longitude,
                Latitude = restaurant.Latitude,
                ImageUrl = restaurant.ImageUrl,
                Rate = restaurant.Rate,
            };
            if (restaurant == null)
            {
                return NotFound();
            }

            patchDTO.ApplyTo(restoDTO, ModelState);
            Restaurant resto = new Restaurant()
            {
                Id = restoDTO.Id,
                Name = restoDTO.Name,
                Description = restoDTO.Description,
                Longitude = restoDTO.Longitude,
                Latitude = restoDTO.Latitude,
                ImageUrl = restoDTO.ImageUrl,
                Rate = restoDTO.Rate,
                CreatedDate = restaurant.CreatedDate,
                UpdatedDate = DateTime.UtcNow,
            };

            _context.Restaurants.Update(resto);
            _context.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();

        }
    }
}
