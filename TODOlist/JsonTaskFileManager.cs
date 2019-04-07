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
        public void MakeJsonFile(ObservableCollection<TaskItem> TaskList)
        {
            string json = JsonConvert.SerializeObject(TaskList.ToList());
            Trace.WriteLine(json);
            tempJson = json;
        }

        public List<TaskItem> ReadJsonFile()
        {
            return JsonConvert.DeserializeObject<List<TaskItem>>(tempJson);
        }
    }
}
