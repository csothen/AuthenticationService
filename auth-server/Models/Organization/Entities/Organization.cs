using System;
using System.ComponentModel.DataAnnotations;

namespace auth_server.Models.OrganizationModels
{
    public class Organization
    {
        [Key]
        public Guid _oid { get; private set; }
        public Guid? _templateId { get; private set; }
        public string _email { get; private set; }
        public string _name { get; private set; }
        public Address _address { get; private set; }
        public string _password { get; private set; }
        public string _salt { get; private set; }

        public Organization(string email, string name, Address address, string password, string salt)
        {
            this._oid = new Guid();
            this._email = email;
            this._name = name;
            this._address = address;
            this._password = password;
            this._salt = salt;
        }

        public Organization()
        {
            //Default
        }

        public void associateTemplate(Guid templateId)
        {
            this._templateId = templateId;
        }
    }
}