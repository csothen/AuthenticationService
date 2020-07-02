namespace auth_server.Models.OrganizationModels
{
    public class Organization
    {
        private string _email;
        private string _name;
        private Address _address;
        private string _password;
        private string _salt;

        public Organization(string email, string name, Address address, string password, string salt)
        {
            this._email = email;
            this._name = name;
            this._address = address;
            this._password = password;
            this._salt = salt;
        }
    }
}