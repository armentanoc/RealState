using Microsoft.AspNetCore.Mvc;
using RealState.Application;
using RealState.Domain;

namespace RealState.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealStateController : ControllerBase
    {
        private readonly ILogger<RealStateController> _logger;
        private readonly IPropertyService _propertyService;

        public RealStateController(ILogger<RealStateController> logger, IPropertyService propertyService)
        {
            _logger = logger;
            _propertyService = propertyService;
        }

        [HttpGet("properties", Name = "GetAllProperties")]
        public ActionResult<IEnumerable<Property>> GetProperties()
        {
            var allProperties = _propertyService.GetAllProperties();
            return Ok(allProperties);
        }

        [HttpGet("properties/{id}", Name = "GetPropertyById")]
        public ActionResult<Property> GetPropertyById(int id)
        {
            if (_propertyService.GetPropertyById(id) is not Property property)
                return NotFound();
            return Ok(property);
        }

        [HttpPost("properties", Name = "AddProperty")]
        public ActionResult<int> AddProperty([FromForm] Property property)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newId = _propertyService.AddProperty(property);
            return Ok(newId);
        }

        [HttpDelete("properties/{id}", Name = "DeleteProperty")]
        public IActionResult DeleteProperty(int id)
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
        
        [HttpPut("properties/{id}", Name = "UpdateProperty")]
        public ActionResult UpdateProperty(int id, [FromForm] Property viewProperty)
        {
            try
            {
                viewProperty.Id = id;
                _propertyService.UpdateProperty(viewProperty);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
