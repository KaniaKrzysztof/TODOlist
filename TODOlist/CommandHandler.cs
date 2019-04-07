using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TODOlist
{
    public class CommandHandler : TaskApiClient
    {
        protected string _path;
        public CommandHandler(string uriString = "https://localhost:44321/", string path = "/api/task") : base(uriString)
        {
            _path = path;
        }

        public async Task<HttpStatusCode> DeleteTaskItemAsync(long id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"{_path}/{id.ToString()}");
            return response.StatusCode;
        }

        public async Task<Uri> CreateTasktAsync(TaskItem taskItem)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(
                _path, taskItem);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
    }
}