using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Planner.Core
{
    class Planner
    {
        public Planner()
        {
            LoadData();
        }

        public void AddEvent(Event _event)
        {
            Events.Add(_event);
        }

        private List<Event> Events = new List<Event>();
        private T Deserialize<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }

        private void Serialize<T>(string fileName, T data)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, data);
                }
            }
        }

        private const string EventsFileName = "../../../../../Planner/data/Events.json";


        private void LoadData()
        {
            Events = Deserialize<List<Event>>(EventsFileName);
        }

        private void SaveData()
        {
            Serialize(EventsFileName, Events);
        }
    }
}
