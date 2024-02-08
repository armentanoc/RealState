using Microsoft.AspNetCore.Mvc;
using RealState.Application;
using RealState.Domain;
using RealState.WebAPI.Helpers;
using RealState.WebAPI.Helpers.Cep;
using RealState.WebAPI.Helpers.Requests;
using RealState.WebAPI.Requests.RealState.WebAPI.Requests;
using Swashbuckle.AspNetCore.Annotations;
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

        [HttpGet("imovel")]
        [SwaggerOperation("Get all properties")]
        public ActionResult<IEnumerable<Property>> GetProperties()
        {
            var allProperties = _propertyService.GetAllProperties();
            return Ok(allProperties);
        }

        [HttpGet("imovel/{id}")]
        [SwaggerOperation("Get a property by ID")]
        public ActionResult<Property> GetPropertyById([FromRoute] int id)
        {
            if (_propertyService.GetPropertyById(id) is not Property property)
                return NotFound();
            return Ok(property);
        }

        [HttpPost("imovel")]
        [SwaggerOperation("Add a property by CEP and Price")]
        public async Task<ActionResult<int>> AddProperty([FromForm][Required] string cep, [FromForm][Required] decimal price)
        {
            try
            {
                var addressResponse = await CepApiHelper.GetAddressDetailsAsync(cep);

                if (addressResponse.IsSuccessStatusCode)
                {
                    var addressDetails = await addressResponse.Content.ReadFromJsonAsync<AddressDetailsResponse>();
                    var property = ControllerHelper.ParseToProperty(addressDetails, price);
                    _propertyService.AddProperty(property);
                    return CreatedAtAction(nameof(AddProperty), new { id = property.Id }, property);
                }
                else
                {
                    return BadRequest("Failed to retrieve address details from the external CEP API.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("imovel/without_cep")]
        [SwaggerOperation("Add a property by full address and price")]
        public ActionResult AddPropertyWithoutCep([FromForm][Required] RequiredPropertyRequest requestProperty)
        {
            try
            {
                var property = ControllerHelper.ParseToProperty(requestProperty);
                _propertyService.AddProperty(property);
                return CreatedAtAction(nameof(AddProperty), new { id = property.Id }, property);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("imovel/{id}")]
        [SwaggerOperation("Delete a property by ID")]
        public IActionResult DeleteProperty([FromRoute] int id)
        {
            try
            {
                _propertyService.DeleteProperty(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("imovel/{id}")]
        [SwaggerOperation("Update a property by ID")]
        public ActionResult UpdateProperty([FromRoute] int id, [FromBody][Required] RequiredPropertyRequest requestProperty)
        {
            try
            {
                var property = _propertyService.GetPropertyById(id);
                property = ControllerHelper.ParseToProperty(requestProperty, id);
                _propertyService.UpdateProperty(property);
                return Ok(property);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, $"Internal Server Error - {ex.Message}");
            }
        }
    }
}
