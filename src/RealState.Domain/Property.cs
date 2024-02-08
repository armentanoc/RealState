
namespace RealState.Domain
{
    public class Property
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public decimal Price { get; set; }
    }
}
