using AutoMapper;
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
        private readonly IMapper _mapper;

        public RestaurantAPIController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetRestaurants()
        {
            IEnumerable<Restaurant> restaurantList = await _context.Restaurants.ToListAsync();
            return Ok(_mapper.Map<List<RestaurantDTO>>(restaurantList));
        }

        [HttpGet("{id:int}", Name = "GetRestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurant(int id)
        {
            if ( id == 0)
            {
                return BadRequest();
            }
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
            if (restaurant == null )
            {
                return NotFound();
            }            
            return Ok(_mapper.Map<RestaurantDTO>(restaurant));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RestaurantDTO>> CreateRestaurant([FromBody]RestaurantCreateDTO createDTO)
        {
            if (await _context.Restaurants.FirstOrDefaultAsync(x=> x.Name.ToLower()==createDTO.Name.ToLower())!= null)
            {
                ModelState.AddModelError("CustomError", "Restaurant already exist!");
                return BadRequest(ModelState);
            }

            if (createDTO == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            Restaurant restaurant = _mapper.Map<Restaurant>(createDTO);
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetRestaurant", new {id = restaurant.Id }, restaurant);
        }

        [HttpDelete("{id:int}", Name = "DeleteRestaurant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpPut("{id:int}", Name = "UpdateRestaurant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] RestaurantUpdateDTO restaurantDTO)
        {
            if (restaurantDTO == null || id != restaurantDTO.Id)
            {
                return BadRequest();
            }


            Restaurant restaurant = _mapper.Map<Restaurant>(restaurantDTO);
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpPatch("{id:int}", Name = "UpdatePartialRestaurant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartialRestaurant(int id, JsonPatchDocument<RestaurantUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var restaurant = await _context.Restaurants.AsNoTracking().FirstOrDefaultAsync(x => x.Id ==id);

            RestaurantUpdateDTO restaurantDTO = _mapper.Map<RestaurantUpdateDTO>(restaurant);

            if (restaurant == null)
            {
                return NotFound();
            }

            patchDTO.ApplyTo(restaurantDTO, ModelState);
            Restaurant model = _mapper.Map<Restaurant>(restaurantDTO);

            _context.Restaurants.Update(model);
            await _context.SaveChangesAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();

        }
    }
}
