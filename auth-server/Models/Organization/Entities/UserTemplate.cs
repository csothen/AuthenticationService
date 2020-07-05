using System;
using System.Collections.Generic;

namespace auth_server.Models.OrganizationModels
{
    public class UserTemplate
    {
        // ID of the template
        public Guid _tid { get; private set; }
        // Dictionary containing all the attributes that are going to be persisted
        private Dictionary<string, ENUM_TYPES> _attributes;

        public UserTemplate(Dictionary<string, ENUM_TYPES> attributes)
        {
            this._attributes = attributes;
        }

        public UserTemplate()
        {
            // Default
        }
    }
}