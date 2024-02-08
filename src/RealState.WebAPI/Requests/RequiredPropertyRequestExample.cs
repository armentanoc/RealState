using RealState.Application;
using Swashbuckle.AspNetCore.Filters;


namespace RealState.WebAPI.Requests
{
    public class RequiredPropertyRequestExample : IExamplesProvider<RequiredPropertyRequest>
    {
        private readonly IPropertyService _propertyService;
        private readonly int _id;
        public RequiredPropertyRequestExample(IPropertyService propertyService, int id)
        {
            _propertyService = propertyService;
            _id = id;
        }

        public RequiredPropertyRequest GetExamples()
        {
            var exampleProperty = _propertyService.GetPropertyById(_id);

            return new RequiredPropertyRequest
            {
                Cep = exampleProperty.Cep,
                State = exampleProperty.State,
                City = exampleProperty.City,
                Neighborhood = exampleProperty.Neighborhood,
                Street = exampleProperty.Street,
                Price = exampleProperty.Price
            };
        }
    }
}
