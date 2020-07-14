using System.Collections.Generic;
using auth_server.Models.UserTemplateModels;

namespace auth_server.Controllers.Commands
{
    public class CreateTemplateCommand : ICommand
    {
        public ICollection<UserTemplateAttribute> attributes { get; set; }


        public bool Validate()
        {
            return attributes.Count != 0;
        }
    }
}