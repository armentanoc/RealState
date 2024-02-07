
using RealState.Domain;

namespace RealState.Infra
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(int id);
        int AddProperty(Property property);
        void DeleteProperty(int id);
    }
}
