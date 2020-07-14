using System;

namespace auth_server.Models.OrganizationModels
{
    public class OrganizationDTO
    {
        public string email { get; set; }
        public string name { get; set; }

        public OrganizationDTO(string p_email, string p_name)
        {
            this.email = p_email;
            this.name = p_name;
        }
    }

}