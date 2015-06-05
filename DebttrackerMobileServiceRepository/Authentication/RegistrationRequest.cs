using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DebttrackerMobileServiceRepository.Authentication
{
    /// <summary>
    /// Collect and store other user information during registration here
    /// </summary>
    public class RegistrationRequest
    {
        [JsonProperty(PropertyName = "Email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Username", Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "Password", Required = Required.Always)]
        public string Password { get; set; }
    }
}
