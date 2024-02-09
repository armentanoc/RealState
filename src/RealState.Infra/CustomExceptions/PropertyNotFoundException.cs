
namespace RealState.Infra
{
    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(string? message = "Property not found") : base(message)
        {
        }
    }
}