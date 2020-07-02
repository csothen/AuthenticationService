using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace auth_server.Models.OrganizationModels
{
    public class CountryInfo
    {
        private Dictionary<string, List<string>> _info;
        private WebClient _client;
        public CountryInfo()
        {
            this._client = new WebClient();
            this._info = setup().Result;
        }

        private async Task<Dictionary<string, List<string>>> setup()
        {
            Dictionary<string, List<string>> info = new Dictionary<string, List<string>>();
            List<string> countries = new List<string>();
            Uri uriCountries = new Uri("https://restcountries.eu/rest/v2/all");
            var countriesResponse = this._client.DownloadString(uriCountries);
            var jsonString = JsonConvert.DeserializeObject<List<JObject>>(countriesResponse);
            this._client.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7InVzZXJfZW1haWwiOiJwb2V0LmNsYXlib3JuQGFuZHllcy5uZXQiLCJhcGlfdG9rZW4iOiJjb3BUWEpEbVVhN3V5RTBVT25MaTYwSmdlNFVobnd0SXVETHNucVY0YnZnRm9BcnVuYzZDSmJrT05EWFY5SnNZQnJBIn0sImV4cCI6MTU5Mzc5NzEzMH0.dNuQCDIYl6T1gy_tDIEOX9ZtnXH054Fh6gv1AsBFQY0");
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