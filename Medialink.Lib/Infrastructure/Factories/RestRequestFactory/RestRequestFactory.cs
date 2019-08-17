using RestSharp;

namespace MediaLink.Lib.RestRequestFactory
{
    public class RestRequestFactory : IRestRequestFactory
    {
        public RestRequest Create(string url, Method method)
        {
            return new RestRequest(url, method);
        }
    }
}
