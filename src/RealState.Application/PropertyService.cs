using RealState.Domain;
using RealState.Infra;

namespace RealState.Application
{
    public class PropertyService : IRealStateService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _propertyRepository.GetAllProperties();
        }

        public Property GetPropertyById(int id)
        {
            return _propertyRepository.GetPropertyById(id);
        }

        public int AddProperty(Property property)
        {
            return _propertyRepository.AddProperty(property);
        }
        public void DeleteProperty(int id)
        {
            _propertyRepository.DeleteProperty(id); ;
        }
    }
}
