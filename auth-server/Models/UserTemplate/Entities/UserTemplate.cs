using System;
using System.Collections.Generic;

namespace auth_server.Models.UserTemplateModels
{
    public class UserTemplate
    {
        // ID of the template
        public Guid _tid { get; private set; }
        // Dictionary containing all the attributes that are going to be persisted
        public ICollection<UserTemplateAttribute> _attributes { get; private set; }

        public UserTemplate(ICollection<UserTemplateAttribute> attributes)
        {
            this._attributes = attributes;
        }

        public UserTemplate()
        {
            // Default
        }
    }
}