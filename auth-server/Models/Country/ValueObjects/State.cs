using Newtonsoft.Json;

namespace auth_server.Models.CountryModels
{
    public class State
    {
        [JsonProperty("state_name")]
        private string _name;

        public State(string name)
        {
            this._name = name;
        }
    }
}