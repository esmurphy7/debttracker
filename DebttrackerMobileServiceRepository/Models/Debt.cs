using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebttrackerMobileServiceRepository.Models
{
    public class Debt : EntityModel
    {
        [JsonProperty(PropertyName = "SourceUser", Required = Required.Always)]
        public User SourceUser { get; set; }

        [JsonProperty(PropertyName = "TargetUser", Required = Required.Always)]
        public User TargetUser { get; set; }

        [JsonProperty(PropertyName = "Amount", Required = Required.Always)]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Group")]
        public Group Group { get; set; }
    }
}
