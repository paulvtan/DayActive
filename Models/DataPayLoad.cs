using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DayActive.Engine.App.Models
{
    public class DataPayLoad
    {
        [JsonProperty(PropertyName = "game")]
        public string Game { get; set; }
        [JsonProperty(PropertyName = "event")]
        public string Event { get; set; }
        [JsonProperty(PropertyName = "data")]
        public Data Data { get; set; }
    }
    
    public class Data
    {
        [JsonProperty(PropertyName = "value")]
        public double Value { get; set; }
    }
}
