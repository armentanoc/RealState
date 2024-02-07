using System.ComponentModel.DataAnnotations;

namespace RealState.WebAPI.Requests
{
    public record RequiredPropertyRequest {

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get;}

        public RequiredPropertyRequest()
        {
            // required by the model binder
        }
        public RequiredPropertyRequest(string street, string city, string state, decimal price)
        {
            Street = street;
            City = city;
            State = state;
            Price = price;
        }
    }
}
