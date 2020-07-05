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

        public async Task<bool> SetupCountries()
        {
            try
            {
                string token = this._config["CountriesAPIToken"];
                string baseURI = "https://www.universal-tutorial.com/api/";

                this._client.Headers.Add("Authorization", "Bearer " + token);

                Uri countriesUri = new Uri(baseURI + "countries");
                string countriesRes = await this._client.DownloadStringTaskAsync(countriesUri);
                List<JObject> jsonCountriesRes = JsonConvert.DeserializeObject<List<JObject>>(countriesRes);
                jsonCountriesRes.ForEach(async (JObject country) =>
                {
                    string name = country["country_name"].ToString();
                    Uri statesUri = new Uri(baseURI + "states/" + name);
                    string statesRes = await this._client.DownloadStringTaskAsync(statesUri);
                    JArray jsonStatesRes = JsonConvert.DeserializeObject<JArray>(statesRes);
                    await this._repo.Create(new Country(name, jsonStatesRes.ToObject<List<State>>()));
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Country>> GetCountries()
        {
            List<Country> countries = await _repo.GetAll();
            return countries;
        }
    }
}