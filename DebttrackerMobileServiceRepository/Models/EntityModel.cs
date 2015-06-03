using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebttrackerMobileServiceRepository.Models
{
    public abstract class EntityModel
    {
        [JsonProperty()]
        public string id { get; set; }
    }
}
