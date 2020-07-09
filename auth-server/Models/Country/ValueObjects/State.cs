using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace auth_server.Models.CountryModels
{
    [Owned]
    public class State
    {
        [JsonProperty("state_name")]
        public string name { get; private set; }

        public State(string p_name)
        {
            this.name = p_name;
        }

        public State()
        {
            // Default
        }
    }
}