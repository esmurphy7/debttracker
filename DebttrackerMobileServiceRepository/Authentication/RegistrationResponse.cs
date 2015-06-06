using System.Net;
using Newtonsoft.Json;

namespace DebttrackerMobileServiceRepository.Authentication
{
    public class RegistrationResponse
    {
        [JsonProperty(PropertyName = "StatusCode", Required = Required.Always)]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty(PropertyName = "Message", Required = Required.Always)]
        public string Message { get; set; }
    }
}
