using Microsoft.AspNetCore.Mvc;
using RealState.Application;
using RealState.Domain;
using RealState.WebAPI.Requests;
using System.ComponentModel.DataAnnotations;

namespace RealState.WebAPI.Controllers
{
    [ApiController]
    public class RealStateController : ControllerBase
    {
        private readonly ILogger<RealStateController> _logger;
        private readonly IPropertyService _propertyService;

        public RealStateController(ILogger<RealStateController> logger, IPropertyService propertyService)
        {
            _logger = logger;
            _propertyService = propertyService;
        }

        [HttpGet("imovel", Name = "GetAllProperties")]
        public ActionResult<IEnumerable<Property>> GetProperties()
        {
            var allProperties = _propertyService.GetAllProperties();
            return Ok(allProperties);
        }

        [HttpGet("imovel/{id}", Name = "GetPropertyById")]
        public ActionResult<Property> GetPropertyById([FromRoute] int id)
        {
            if (_propertyService.GetPropertyById(id) is not Property property)
                return NotFound();
            return Ok(property);
        }

        [HttpPost("imovel", Name = "AddProperty")]
        public ActionResult<int> AddProperty([FromForm][Required] RequiredPropertyRequest requestProperty)
        {
            var property = ParseToProperty(requestProperty);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = _propertyService.AddProperty(property);
            return Created($"imovel/{property.Id}", property);
        }

        [HttpDelete("imovel/{id}", Name = "DeleteProperty")]
        public IActionResult DeleteProperty([FromRoute] int id)
        {
            try
            { 
                _propertyService.DeleteProperty(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpPut("imovel/{id}", Name = "UpdateProperty")]
        public ActionResult UpdateProperty([FromRoute] int id, [FromForm][Required] RequiredPropertyRequest requestProperty)
        {
            try
            {
                Property property = ParseToProperty(requestProperty);
                property.Id = id;
                _propertyService.UpdateProperty(property);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        private Property ParseToProperty(RequiredPropertyRequest requestProperty)
        {
            return new Property
            {
                Street = requestProperty.Street,
                City = requestProperty.City,
                State = requestProperty.State,
                Price = requestProperty.Price
            };
        }
    }
}
