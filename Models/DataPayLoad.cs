using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayActive.Engine.App.Models
{
    public class DataPayLoad
    {
        public string game { get; set; }
        public string @event { get; set; }
        public Data data { get; set; }
    }
    
    public class Data
    {
        public double value { get; set; }
    }
}
