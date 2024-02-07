using Microsoft.AspNetCore.Mvc;
using RealState.Application;
using RealState.Domain;
using RealState.WebAPI.Requests;
using RealState.WebAPI.Requests.RealState.WebAPI.Requests;
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
        public async Task<ActionResult<int>> AddProperty([FromForm][Required] string cep)
        {
            var addressResponse = await GetAddressDetailsAsync(cep);

            if (addressResponse.IsSuccessStatusCode)
            {
                var addressDetails = await addressResponse.Content.ReadFromJsonAsync<AddressDetailsResponse>();

                // Display the address details to the user
                Console.WriteLine($"Address Details:");
                Console.WriteLine($"State: {addressDetails.State}");
                Console.WriteLine($"City: {addressDetails.City}");
                Console.WriteLine($"Neighborhood: {addressDetails.Neighborhood}");
                Console.WriteLine($"Street: {addressDetails.Street}");
                Console.WriteLine($"Service: {addressDetails.Service}");

                // Prompt the user to input the price
                Console.Write("Enter the price: ");
                if (decimal.TryParse(Console.ReadLine(), out var price))
                {
                    // Now you have the address details and the input price
                    // Perform further processing (e.g., creating a Property object and saving it)
                    // ...

                    Console.WriteLine("Property added successfully!");
                    return Ok(); // or return Created, depending on your use case
                }
                else
                {
                    // Handle invalid price input
                    return BadRequest("Invalid price input.");
                }
            }
            else
            {
                // Handle the case where the API request fails
                // Return an appropriate error response
                return BadRequest("Failed to retrieve address details from the external API.");
            }
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

        private async Task<HttpResponseMessage> GetAddressDetailsAsync(string cep)
        {
            using (var client = new HttpClient())
            {
                var requestUri = $"https://brasilapi.com.br/api/cep/v1/{cep}";
                return await client.GetAsync(requestUri);
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
