using RealState.Domain;
using RealState.WebAPI.Requests.RealState.WebAPI.Requests;
using RealState.WebAPI.Requests;

namespace RealState.WebAPI.Helpers
{
    public class PropertyHelper
    {
        internal static Property ParseToProperty(RequiredPropertyRequest requestProperty)
        {
            return new Property
            {
                Cep = requestProperty.Cep,
                State = requestProperty.State,
                City = requestProperty.City,
                Neighborhood = requestProperty.Neighborhood,
                Street = requestProperty.Street,
                Price = requestProperty.Price
            };
        }
        internal static Property ParseToProperty(RequiredPropertyRequest requestProperty, int id)
        {
            return new Property
            {
                Id = id,
                Cep = requestProperty.Cep,
                State = requestProperty.State,
                City = requestProperty.City,
                Neighborhood = requestProperty.Neighborhood,
                Street = requestProperty.Street,
                Price = requestProperty.Price
            };
        }
        internal static Property ParseToProperty(AddressDetailsResponse addressDetails, decimal price)
        {
            return new Property
            {
                Cep = addressDetails.Cep,
                State = addressDetails.State,
                City = addressDetails.City,
                Neighborhood = addressDetails.Neighborhood,
                Street = addressDetails.Street,
                Price = price
            };
        }
    }
}
