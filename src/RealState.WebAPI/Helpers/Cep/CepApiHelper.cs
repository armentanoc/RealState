namespace RealState.WebAPI.Helpers.Cep
{
    public class CepApiHelper
    {
        internal static async Task<HttpResponseMessage> GetAddressDetailsAsync(string cep)
        {
            using (var client = new HttpClient())
            {
                var requestUri = $"https://brasilapi.com.br/api/cep/v1/{cep}";
                return await client.GetAsync(requestUri);
            }
        }
    }
}
