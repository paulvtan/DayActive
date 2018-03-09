using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DayActive.Engine.App.Models
{
    public class GameHeartBeat
    {
        [JsonProperty(PropertyName = "game")]
        public string Game { get; set; }
    }
}
