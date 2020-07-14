using System;
using System.Collections.Generic;

namespace auth_server.Models.UserTemplateModels
{
    public class UserTemplateDTO
    {

        public Guid _tid { get; set; }
        public ICollection<UserTemplateAttribute> attributes { get; set; }

        public UserTemplateDTO(Guid id, ICollection<UserTemplateAttribute> attrs)
        {
            this._tid = id;
            this.attributes = attrs;
        }
    }
}