using System.ComponentModel.DataAnnotations;

namespace RealState.WebAPI.Requests
{
    public record RequiredPropertyRequest {

        [Required(ErrorMessage = "Cep is required")]
        public string Cep { get; init; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; init; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; init; }

        [Required(ErrorMessage = "Neighborhood is required")]
        public string Neighborhood { get; init; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; init; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; init; }

        public string Service { get; init; }

        public RequiredPropertyRequest()
        {
            // required by the model binder
        }

        public RequiredPropertyRequest(string cep, string state, string city, string neighborhood, string street, string service, decimal price)
        {
            Cep = cep;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            Street = street;
            Service = service;
            Price = price;
        }
    }
}
