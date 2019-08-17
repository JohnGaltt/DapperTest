using RestSharp;

namespace MediaLink.Lib.RestClientFactory
{

    public class RestClientFactory : IRestClientFactory
    {
        public RestClient Create(string baseUrl)
        {
            return new RestClient(baseUrl);
        }
    }
}
