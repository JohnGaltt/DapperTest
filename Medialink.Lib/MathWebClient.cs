using Dapper;
using MediaLink.Lib.DataAccess.Models;
using MediaLink.Lib.RestClientFactory;
using MediaLink.Lib.RestRequestFactory;
using RestSharp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MediaLink.Lib
{
    public class MathWebClient
    {
        private readonly IRestClient _restClient;
        private readonly IRestClientFactory _restClientFactory;
        private readonly IRestRequestFactory _restRequestFactory;
        private readonly string _baseUrl;

        public MathWebClient(IRestClientFactory restClientFactory, IRestRequestFactory restRequestFactory)
        {
            _baseUrl = "http://localhost:55417/";
            _restClientFactory = restClientFactory;
            _restRequestFactory = restRequestFactory;
        }
            
        public int Add(int a, int b)
        {
            var restClient = _restClientFactory.Create(_baseUrl);
            var restRequest = _restRequestFactory.Create($"api/math/add?a={a}&b={b}", Method.GET);
            var sum = restClient.Get(restRequest).Content;
            using (IDbConnection db = new SqlConnection("Server=DESKTOP-EC5FMB7\\SQLEXPRESS;Database=DapperTest;Trusted_Connection=True;MultipleActiveResultSets=true;"))  
            {
                var query = $"INSERT INTO ImportantObject VALUES(1,{sum})";
                int rowsAffected = db.Execute(query);
            }  
            //log the request

            return Convert.ToInt32(sum);
        }

        public int Multiply(int a, int b)
        {
            var restClient = _restClientFactory.Create(_baseUrl);
            var restRequest = _restRequestFactory.Create($"multiply?a={a}&b={b}", Method.GET);
            var product = restClient.Get(restRequest).Content;

            using (IDbConnection db = new SqlConnection("Server=DESKTOP-EC5FMB7\\SQLEXPRESS;Database=DapperTest;Trusted_Connection=True;MultipleActiveResultSets=true;"))
            {
                var query = $"INSERT INTO ImportantObject VALUES(1,{product})";
                int rowsAffected = db.Execute(query);
            }
            return Convert.ToInt32(product);
        }

        public int Divide(int a, int b)
        {
            var restClient = _restClientFactory.Create(_baseUrl);
            var restRequest = _restRequestFactory.Create($"divide?a={a}&b={b}", Method.GET);
            var quotient = restClient.Get(restRequest).Content;

            using (IDbConnection db = new SqlConnection("Server=DESKTOP-EC5FMB7\\SQLEXPRESS;Database=DapperTest;Trusted_Connection=True;MultipleActiveResultSets=true;"))
            {
                var query = $"INSERT INTO ImportantObject VALUES(1,{quotient})";
                int rowsAffected = db.Execute(query);
            }

            return Convert.ToInt32(quotient);
        }
    }
}
