using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebttrackerMobileServiceRepository.Models
{
    public class Friend : EntityModel
    {
        [JsonProperty(PropertyName = "UserA", Required = Required.Always)]
        public User UserA { get; set; }
        [JsonProperty(PropertyName = "UserB", Required = Required.Always)]
        public User UserB { get; set; }
        [JsonProperty(PropertyName = "Status", Required = Required.Always)]
        public FriendStatus Status { get; set; }
    }

    public sealed class FriendStatus
    {
        public static readonly FriendStatus Accepted = new FriendStatus("accepted");
        public static readonly FriendStatus Pending = new FriendStatus("pending");
        public static readonly FriendStatus Declined = new FriendStatus("declined");

        public string Value { get; private set; }

        private FriendStatus(string status)
        {
            Value = status;
        }
    }
}
