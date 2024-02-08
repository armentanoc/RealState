
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
            if (properties.FirstOrDefault(p => p.Id == id) is Property property)
                return property;
            else
                throw new IdNotFoundException($"Property with id {id} not found");
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
            try
            {
                var existingProperty = GetPropertyById(newProperty.Id);
                existingProperty.Cep = newProperty.Cep;
                existingProperty.State = newProperty.State;
                existingProperty.City = newProperty.City;
                existingProperty.Neighborhood = newProperty.Neighborhood;
                existingProperty.Street = newProperty.Street;
                existingProperty.Price = newProperty.Price;
            }
            catch 
            {
                throw new Exception($"We couldn't update property {newProperty.Id}");
            }
        }
    }
}
