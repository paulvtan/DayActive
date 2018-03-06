using System.Collections.Generic;
using Newtonsoft.Json;

namespace DayActive.Engine.App.Models
{
    public class BindGameEvent
    {
        [JsonProperty(PropertyName = "game")]
        public string Game { get; set; }
        [JsonProperty(PropertyName = "event")]
        public string Event { get; set; }
        [JsonProperty(PropertyName = "icon_id")]
        public int IconId { get; set; }
        [JsonProperty(PropertyName = "handlers")]
        public List<Handlers> Handlers { get; set; }
    }

    
    public class Handlers
    {
        [JsonProperty(PropertyName = "device-type")]
        public string DeviceType { get; set; }
        [JsonProperty(PropertyName = "zone")]
        public string Zone { get; set; }
        [JsonProperty(PropertyName = "mode")]
        public string Mode { get; set; }
        [JsonProperty(PropertyName = "datas")]
        public List<Datas> Datas { get; set; }
    }

    public class Datas
    {
        [JsonProperty(PropertyName = "length-millis")]
        public int LengthMillis { get; set; }
        [JsonProperty(PropertyName = "has-text")]
        public bool HasText { get; set; }
        [JsonProperty(PropertyName = "prefix")]
        public string PreFix { get; set; }
        [JsonProperty(PropertyName = "icon-id")]
        public int IconId { get; set; }
        [JsonProperty(PropertyName = "suffix")]
        public string Suffix { get; set; }
        [JsonProperty(PropertyName = "repeats")]
        public bool Repeats { get; set; }
    }
}
