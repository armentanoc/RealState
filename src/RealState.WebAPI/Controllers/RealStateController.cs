using Microsoft.AspNetCore.Mvc;
using RealState.Application;
using RealState.Domain;
using RealState.WebAPI.CustomExceptions;

namespace RealState.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealStateController : ControllerBase
    {
        private readonly ILogger<RealStateController> _logger;
        private readonly IRealStateService _realStateService;

        public RealStateController(ILogger<RealStateController> logger, IRealStateService realStateService)
        {
            _logger = logger;
            _realStateService = realStateService;
        }

        [HttpGet("properties", Name = "GetAllProperties")]
        public ActionResult<IEnumerable<Property>> GetProperties()
        {
            var allProperties = _realStateService.GetAllProperties();
            return Ok(allProperties);
        }

        [HttpGet("properties/{id}", Name = "GetPropertyById")]
        public ActionResult<Property> GetPropertyById(int id)
        {
            if (_realStateService.GetPropertyById(id) is not Property property)
                return NotFound();
            return Ok(property);
        }

        [HttpPost("properties", Name = "AddProperty")]
        public ActionResult<int> AddProperty([FromForm] Property property)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newId = _realStateService.AddProperty(property);
            return Ok(newId);
        }

        [HttpDelete("properties/{id}", Name = "DeleteProperty")]
        public IActionResult DeleteProperty(int id)
        {
            try
            { 
                _realStateService.DeleteProperty(id);
                return NoContent();
            }
            catch (IdNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
