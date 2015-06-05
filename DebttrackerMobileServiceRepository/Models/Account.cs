using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebttrackerMobileServiceRepository.Models
{
    public class Account : EntityModel
    {
        [JsonProperty(PropertyName = "Email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Username", Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "Salt", Required = Required.Always)]
        public byte[] Salt { get; set; }

        [JsonProperty(PropertyName = "SaltedAndHashedPassword", Required = Required.Always)]
        public byte[] SaltedAndHashedPassword { get; set; }
    }
}
