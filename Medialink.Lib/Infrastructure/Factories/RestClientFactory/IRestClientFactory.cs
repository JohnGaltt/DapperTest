using RestSharp;

namespace MediaLink.Lib.RestClientFactory
{
    public interface IRestClientFactory
    {
        RestClient Create(string baseUrl);
    }
}
