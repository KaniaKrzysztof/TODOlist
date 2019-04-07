using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TODOlist
{
    public class TaskApiClient
    {
        protected HttpClient _client;
        public TaskApiClient(string uriString = "https://localhost:44321")
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(uriString)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
