using System.ComponentModel.DataAnnotations;

namespace RealState.WebAPI.Helpers.Requests
{
    public class RequiredPropertyRequest
    {

        [Required(ErrorMessage = "Cep is required")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Neighborhood is required")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        public RequiredPropertyRequest()
        {
            // required by the model binder
        }

        public RequiredPropertyRequest(string cep, string state, string city, string neighborhood, string street, decimal price)
        {
            Cep = cep;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            Street = street;
            Price = price;
        }
    }
}
