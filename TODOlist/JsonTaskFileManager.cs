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
        public JsonTaskFileManager()
        {

        }
        public void MakeJsonFile(ObservableCollection<Task> TaskList)
        {
            string json = JsonConvert.SerializeObject(TaskList.ToList());
            Trace.WriteLine(json);
            List<Task> reconvertedTaskList = JsonConvert.DeserializeObject<List<Task>>(json);
        }
    }
}
