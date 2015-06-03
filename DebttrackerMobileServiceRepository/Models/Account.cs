using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebttrackerMobileServiceRepository.Models
{
    public class Account : IEntityModel
    {
        [JsonProperty(PropertyName = "Username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "Salt")]
        public byte[] Salt { get; set; }
        [JsonProperty(PropertyName = "SaltedAndHashedPassword")]
        public byte[] SaltedAndHashedPassword { get; set; }
    }
}
