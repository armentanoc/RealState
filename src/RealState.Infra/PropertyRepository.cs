
using RealState.Domain;
using RealState.WebAPI.CustomExceptions;

namespace RealState.Infra
{
    public class PropertyRepository : IPropertyRepository
    {
        private static List<Property> properties = new List<Property>();
        private static int nextId = 1;

        public IEnumerable<Property> GetAllProperties()
        {
            return properties.ToList(); 
        }

        public Property GetPropertyById(int id)
        {
            return properties.FirstOrDefault(p => p.Id == id);
        }

        public int AddProperty(Property property)
        {
            property.Id = nextId++;
            properties.Add(property);
            return (int)property.Id;
        }

        public void DeleteProperty(int id)
        {
            if (properties.FirstOrDefault(p => p.Id == id) is Property property)
            {
                properties.Remove(property);
            } else
            {
                throw new IdNotFoundException($"Property with id {id} not found");
            }
        }
    }
}
