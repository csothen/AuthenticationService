using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using auth_server.Models.OrganizationModels;

namespace auth_server.Models.UserTemplateModels
{
    public class UserTemplate
    {
        // ID of the template
        [Key]
        public Guid _tid { get; private set; }

        // Organization to whom the template belongs
        public Organization organization { get; set; }

        // Dictionary containing all the attributes that are going to be persisted
        public ICollection<UserTemplateAttribute> attributes { get; set; }


        public UserTemplate(Organization organization, ICollection<UserTemplateAttribute> attrs)
        {
            this._tid = new Guid();
            this.organization = organization;
            this.attributes = attrs;
        }

        public UserTemplate()
        {
            // Default
        }
    }
}