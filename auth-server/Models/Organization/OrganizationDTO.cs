using System;

namespace auth_server.Models.OrganizationModels
{
    public class OrganizationDTO
    {
        public Guid _oid;
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }

        public OrganizationDTO(Guid oid, string p_email, string p_name, string p_password)
        {
            this._oid = oid;
            this.email = p_email;
            this.name = p_name;
            this.password = p_password;
        }
    }

}