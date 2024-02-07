
namespace RealState.Infra
{
    internal class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(string? message = "Property not found") : base(message)
        {
        }
    }
}