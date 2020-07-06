using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace auth_server.Models.CountryModels
{
    [Owned]
    public class State
    {
        [JsonProperty("state_name")]
        public string _name { get; private set; }

        public State(string name)
        {
            this._name = name;
        }

        public State()
        {
            // Default
        }
    }
}