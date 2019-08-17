using RestSharp;

namespace MediaLink.Lib.RestRequestFactory
{
    public interface IRestRequestFactory
    {
        RestRequest Create(string url, Method method);
    }
}
