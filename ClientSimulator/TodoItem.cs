using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSimulator
{
    public class TodoItem
    {
        public string id { get; set; }

        [JsonProperty(PropertyName="Text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "Complete")]
        public bool Complete { get; set; }
    }
}
