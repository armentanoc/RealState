using RealState.Domain;

namespace RealState.Application
{
    public interface IPropertyService
    {
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(int id);
        int AddProperty(Property property);
        void UpdateProperty(Property property);
        void DeleteProperty(int id);
    }
}
