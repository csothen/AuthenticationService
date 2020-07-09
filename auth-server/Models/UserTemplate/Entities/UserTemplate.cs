using System;
using System.Collections.Generic;

namespace auth_server.Models.UserTemplateModels
{
    public class UserTemplate
    {
        // ID of the template
        public Guid _tid { get; private set; }
        // Dictionary containing all the attributes that are going to be persisted
        public ICollection<UserTemplateAttribute> attributes { get; set; }

        public UserTemplate(ICollection<UserTemplateAttribute> attrs)
        {
            this.attributes = attrs;
        }

        public UserTemplate()
        {
            // Default
        }
    }
}