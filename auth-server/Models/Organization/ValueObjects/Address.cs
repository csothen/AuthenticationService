namespace auth_server.Models.OrganizationModels
{
    public class Address
    {
        private string _country;
        private string _city;
        private string _streetName;
        private string _postalCode;

        public Address(string country, string city, string streetName, string postalCode)
        {
            this._country = country;
            this._city = city;
            this._streetName = streetName;
            this._postalCode = postalCode;
        }
    }
}