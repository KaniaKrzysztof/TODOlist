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
    public class QueryHandler : TaskApiClient
    {   
        protected string _path;
        public QueryHandler(string uriString = "https://localhost:44321/", string path = "api/task") : base(uriString)
        {
            _path = path;
        }

        public async Task<List<TaskItem>> GetTaskListAsync()
        {
            List<TaskItem> downloadedList = null;
            HttpResponseMessage response = await _client.GetAsync(_path);
            if (response.IsSuccessStatusCode)
            {
                downloadedList = await response.Content.ReadAsAsync<List<TaskItem>>();
            }
            return downloadedList;
        }
    }
}
