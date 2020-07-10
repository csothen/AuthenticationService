using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

using auth_server.Models.CountryModels;
using auth_server.Repositories.CountryContext;

namespace auth_server.Services
{
    public class CountryService : ICountryService
    {
        private readonly IConfiguration _config;
        private WebClient _client;
        private readonly ICountryRepository _repo;

        public CountryService(IConfiguration config, ICountryRepository repo)
        {
            this._config = config;
            this._client = new WebClient();
            this._repo = repo;
        }

        public async Task<bool> Setup()
        {
            try
            {
                string personalToken = this._config["CountriesAPIToken"];
                string email = this._config["CountriesAPIEmail"];
                string baseURI = "https://www.universal-tutorial.com/api/";

                Uri accessTokenUri = new Uri(baseURI + "getaccesstoken");
                this._client.Headers.Add("api-token", personalToken);
                this._client.Headers.Add("user-email", email);

                string tokenRes = await this._client.DownloadStringTaskAsync(accessTokenUri);
                JObject jsonToken = JsonConvert.DeserializeObject<JObject>(tokenRes);
                string token = jsonToken["auth_token"].ToString();


                this._client.Headers.Clear();
                this._client.Headers.Add("Authorization", "Bearer " + token);

                Uri countriesUri = new Uri(baseURI + "countries");
                string countriesRes = await this._client.DownloadStringTaskAsync(countriesUri);
                List<JObject> jsonCountriesRes = JsonConvert.DeserializeObject<List<JObject>>(countriesRes);
                foreach (JObject country in jsonCountriesRes)
                {
                    string name = country["country_name"].ToString();
                    Uri statesUri = new Uri(baseURI + "states/" + name);
                    string statesRes = await this._client.DownloadStringTaskAsync(statesUri);
                    JArray jsonStatesRes = JsonConvert.DeserializeObject<JArray>(statesRes);
                    ICollection<State> states = jsonStatesRes.ToObject<List<State>>();
                    foreach (State state in states)
                        await this._repo.Create(new Country(name, states));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ICollection<Country>> GetCountries()
        {
            ICollection<Country> countries = await _repo.GetAll();
            return countries;
        }
    }
}