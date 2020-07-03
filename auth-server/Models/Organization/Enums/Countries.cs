using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace auth_server.Models.OrganizationModels
{
    public class CountryInfo
    {
        private Dictionary<string, List<string>> _info;
        private WebClient _client;
        private IConfiguration _config;
        public CountryInfo(IConfiguration config)
        {
            this._config = config;
            this._client = new WebClient();
            this._info = setup(this._config["CountriesAPIToken"]).Result;
        }

        private async Task<Dictionary<string, List<string>>> setup(string token)
        {
            Dictionary<string, List<string>> info = new Dictionary<string, List<string>>();
            List<string> countries = new List<string>();
            Uri uriCountries = new Uri("https://restcountries.eu/rest/v2/all");
            var countriesResponse = this._client.DownloadString(uriCountries);
            var jsonString = JsonConvert.DeserializeObject<List<JObject>>(countriesResponse);
            this._client.Headers.Add("Authorization", "Bearer " + token);
            jsonString.ForEach(delegate (JObject o)
            {

                Uri uriStates = new Uri("https://www.universal-tutorial.com/api/states/");
                string country = o["name"].ToString();
                var statesResponse = this._client.DownloadString(uriStates + country);
                var jStates = JsonConvert.DeserializeObject<JArray>(statesResponse);
                List<string> states = new List<string>();
                foreach (JObject state in jStates.Children<JObject>())
                {
                    states.Add(state["state_name"].ToString());
                }
                info.Add(country, states);
            });

            return info;
        }
    }
}