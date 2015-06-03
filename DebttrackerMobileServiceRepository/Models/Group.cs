using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebttrackerMobileServiceRepository.Models
{
    public class Group : IEntityModel
    {
        [JsonProperty(PropertyName = "Users")]
        public ICollection<User> Users { get; set; }
        [JsonProperty(PropertyName = "Debts")]
        public ICollection<Debt> Debts { get; set; }
    }
}
