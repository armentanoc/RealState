namespace RealState.WebAPI.Requests
{
    namespace RealState.WebAPI.Requests
    {
        public record AddressDetailsResponse
        {
            public string Cep { get; init;}
            public string State { get; init; }
            public string City { get; init; }
            public string Neighborhood { get; init; }
            public string Street { get; init; }
            public AddressDetailsResponse(string cep, string state, string city, string neighborhood, string street)
            {
                Cep = cep;
                State = state;
                City = city;
                Neighborhood = neighborhood;
                Street = street;
            }
        }
    }
}