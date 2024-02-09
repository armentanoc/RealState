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
        private readonly IPropertyService _propertyService;

        public RealStateController(IPropertyService propertyService)
        {
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
                throw new Exception($"Property with id {id} not found");
            return Ok(property);
        }

        [HttpPost("imovel")]
        [SwaggerOperation("Add a property by CEP and Price")]
        public async Task<ActionResult<int>> AddProperty([FromForm][Required] string cep, [FromForm][Required] decimal price)
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

        [HttpPost("imovel/without_cep")]
        [SwaggerOperation("Add a property by full address and price")]
        public ActionResult AddPropertyWithoutCep([FromForm][Required] RequiredPropertyRequest requestProperty)
        {
            var property = ControllerHelper.ParseToProperty(requestProperty);
            _propertyService.AddProperty(property);
            return CreatedAtAction(nameof(AddProperty), new { id = property.Id }, property);
        }

        [HttpDelete("imovel/{id}")]
        [SwaggerOperation("Delete a property by ID")]
        public IActionResult DeleteProperty([FromRoute] int id)
        {
            _propertyService.DeleteProperty(id);
            return NoContent();
        }

        [HttpPut("imovel/{id}")]
        [SwaggerOperation("Update a property by ID")]
        public ActionResult UpdateProperty([FromRoute] int id, [FromBody][Required] RequiredPropertyRequest requestProperty)
        {
            var property = _propertyService.GetPropertyById(id);

            if (_propertyService.GetPropertyById(id) is not Property)
                throw new Exception($"Property with id {id} not found");

            property = ControllerHelper.ParseToProperty(requestProperty, id);
            _propertyService.UpdateProperty(property);
            return Ok(property);
        }
    }
}
