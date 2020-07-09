using System;
using System.Collections.Generic;

namespace auth_server.Models.UserTemplateModels
{
    public class UserTemplateDTO
    {

        public Guid _tid;
        public ICollection<UserTemplateAttribute> attributes;
        public UserTemplateDTO(Guid id, ICollection<UserTemplateAttribute> attrs)
        {
            this._tid = id;
            this.attributes = attrs;
        }
    }
}