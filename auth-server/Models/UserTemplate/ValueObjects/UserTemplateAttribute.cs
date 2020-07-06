using Microsoft.EntityFrameworkCore;

namespace auth_server.Models.UserTemplateModels
{
    [Owned]
    public class UserTemplateAttribute
    {
        public string _name { get; private set; }
        public ENUM_TYPES _type { get; private set; }

        public UserTemplateAttribute(string name, ENUM_TYPES type)
        {
            this._name = name;
            this._type = type;
        }

        public UserTemplateAttribute()
        {
            // Default
        }
    }
}