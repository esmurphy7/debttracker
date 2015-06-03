using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebttrackerMobileServiceRepository.Models
{
    public class User : IEntityModel
    {
        [JsonProperty(PropertyName = "Account")]
        public Account Account { get; set; }
        [JsonProperty(PropertyName = "Groups")]
        public ICollection<Group> Groups { get; set; }
    }
}
