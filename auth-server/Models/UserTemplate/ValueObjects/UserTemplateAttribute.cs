using Microsoft.EntityFrameworkCore;

namespace auth_server.Models.UserTemplateModels
{
    [Owned]
    public class UserTemplateAttribute
    {
        public string name { get; set; }
        public ENUM_TYPES type { get; set; }

        public UserTemplateAttribute(string p_name, ENUM_TYPES p_type)
        {
            this.name = p_name;
            this.type = p_type;
        }

        public UserTemplateAttribute()
        {
            // Default
        }
    }
}