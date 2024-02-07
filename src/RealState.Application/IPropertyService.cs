using RealState.Domain;

namespace RealState.Application
{
    public interface IRealStateService
    {
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(int id);
        int AddProperty(Property property);
        void DeleteProperty(int id);
    }
}
