using System;
using System.ComponentModel.DataAnnotations;

namespace auth_server.Models.OrganizationModels
{
    public class Organization
    {
        [Key]
        public Guid _oid { get; private set; }
        public Guid? _templateId { get; private set; }
        public string email { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
        public string password { get; set; }
        public string salt { get; set; }

        public Organization(string p_email, string p_name, Address p_address, string p_password, string p_salt)
        {
            this._oid = new Guid();
            this.email = p_email;
            this.name = p_name;
            this.address = p_address;
            this.password = p_password;
            this.salt = p_salt;
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