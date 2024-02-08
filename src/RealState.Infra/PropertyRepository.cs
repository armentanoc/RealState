
using RealState.Domain;

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
            if (properties.FirstOrDefault(p => p.Id == id) is Property property)
                return property;
            else
                return null;
        }

        public int AddProperty(Property property)
        {
            property.Id = nextId++;
            properties.Add(property);
            return (int)property.Id;
        }

        public void DeleteProperty(int id)
        {
            var property = GetPropertyById(id);
            properties.Remove(property);
        }

        public void UpdateProperty(Property newProperty)
        {
            var existingProperty = GetPropertyById(newProperty.Id);
            existingProperty.Cep = newProperty.Cep;
            existingProperty.State = newProperty.State;
            existingProperty.City = newProperty.City;
            existingProperty.Neighborhood = newProperty.Neighborhood;
            existingProperty.Street = newProperty.Street;
            existingProperty.Price = newProperty.Price;
        }
    }
}
