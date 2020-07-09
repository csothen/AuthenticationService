using Microsoft.EntityFrameworkCore;

namespace auth_server.Models.OrganizationModels
{
    [Owned]
    public class Address
    {
        private string country;
        private string city;
        private string streetName;
        private string postalCode;

        public Address(string p_country, string p_city, string p_streetName, string p_postalCode)
        {
            this.country = p_country;
            this.city = p_city;
            this.streetName = p_streetName;
            this.postalCode = p_postalCode;
        }

        public Address()
        {
            //Default
        }
    }
}