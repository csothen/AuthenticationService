using auth_server.Models.OrganizationModels;

namespace auth_server.Models.Authentication
{
    public class AuthenticationResponse
    {
        public string token;
        public OrganizationDTO organization;

        public AuthenticationResponse(string p_token, OrganizationDTO p_organization)
        {
            this.token = p_token;
            this.organization = p_organization;
        }
    }

}