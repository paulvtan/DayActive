using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DayActive.Engine.App.Models
{
    public class GameMetaData
    {
        [JsonProperty(PropertyName = "game")]
        public string Game { get; set; }
        [JsonProperty(PropertyName = "game_display_name")]
        public string GameDisplayName { get; set; }
        [JsonProperty(PropertyName = "icon_color_id")]
        public int IconColorId { get; set; }
    }
}
