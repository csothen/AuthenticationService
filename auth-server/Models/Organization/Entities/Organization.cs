using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using auth_server.Models.UserTemplateModels;

namespace auth_server.Models.OrganizationModels
{
    public class Organization
    {
        [Key]
        public string email { get; set; }
        public string name { get; set; }
        public ICollection<UserTemplate> _templates { get; private set; }
        public string password { get; set; }
        public string salt { get; private set; }

        public Organization(string p_email, string p_name, string p_password, string p_salt)
        {
            this._templates = new List<UserTemplate>();
            this.email = p_email;
            this.name = p_name;
            this.password = p_password;
            this.salt = p_salt;
        }

        public Organization()
        {
            //Default
        }

        public void associateTemplate(UserTemplate template)
        {
            this._templates.Add(template);
        }
    }
}