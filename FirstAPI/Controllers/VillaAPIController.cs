using FirstAPI.Data;
using FirstAPI.Models;
using FirstAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class VillaAPIController:ControllerBase
    {
        private readonly ILogger<VillaAPIController> _logger;
        private readonly ApplicationDbContext _db;

        public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext db)
        {
            this._logger = logger;
            _db = db;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("Getting All Villas");
            return Ok(_db.Villas.ToList());
        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)

        {
            if (id == 0)
            {
                _logger.LogError("Get Villa with Id Error for " +  id);
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<VillaDTO> CreateVilla([FromBody]VillaCreateDTO villaDTO)
        {
            //  if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if(_db.Villas.FirstOrDefault(u=>u.Name.ToLower() == villaDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Villa Already Exist");
                return BadRequest(ModelState);
            }
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }

          
            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
          
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft
            };
            _db.Villas.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetVilla", new { id = model.Id},model);
        }
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteVilla(int id) {

            if(id == 0)
            {
                return BadRequest();
            }

            var villa  = _db.Villas.FirstOrDefault(u=>u.Id == id);
            if(villa == null)
            {
                return NotFound();
            }

            _db.Villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();
        
        }

        [HttpPut("{id:int}",Name ="UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateVilla(int id,[FromBody] VillaUpdateDTO villaDTO)
        {
            if(villaDTO == null || id!=villaDTO.Id)
            {
                return BadRequest();
            }
            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft
            };
            _db.Villas.Update(model);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
