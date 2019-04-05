using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TODOlist
{
    public class JsonTaskFileManager
    {
        private string tempJson;
        public JsonTaskFileManager()
        {
            tempJson = "";
        }
        public void MakeJsonFile(ObservableCollection<Task> TaskList)
        {
            string json = JsonConvert.SerializeObject(TaskList.ToList());
            Trace.WriteLine(json);
            tempJson = json;
        }

        public List<Task> ReadJsonFile()
        {
            return JsonConvert.DeserializeObject<List<Task>>(tempJson);
        }
    }
}
