using System;
using System.Security;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using auth_server.Controllers.Commands;
using auth_server.Models.Authentication;
using auth_server.Models.OrganizationModels;
using auth_server.Repositories.OrganizationContext;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace auth_server.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IOrganizationRepository _repo;
        private readonly IConfiguration _config;

        public AuthenticationService(IOrganizationRepository repo, IConfiguration config)
        {
            this._repo = repo;
            this._config = config;
        }

        public async Task<AuthenticationResponse> login(LoginCommand command)
        {
            try
            {
                Organization org = await this._repo.GetByEmail(command.email);
                if (org == null) return null;
                string loginPassword = this.encrypt(command.password, org.salt);
                if (loginPassword != org.password) return null;

                var token = generateJwtToken(org);
                OrganizationDTO dto = new OrganizationDTO(org.email, org.name);

                return new AuthenticationResponse(token, dto);
            }
            catch (Exception)
            {
                throw new Exception("Internal error logging in an organization");
            }
        }

        public async Task<AuthenticationResponse> register(RegisterCommand command)
        {
            try
            {
                Organization existingOrg = await this._repo.GetByEmail(command.email);
                if (existingOrg != null) return null;

                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] data = new byte[30];
                rng.GetBytes(data);
                data = new SHA256Managed().ComputeHash(data);
                string salt = Encoding.ASCII.GetString(data);

                string password = this.encrypt(command.password, salt);

                Organization org = new Organization(command.email, command.name, password, salt);

                org = await this._repo.Create(org);

                var token = generateJwtToken(org);
                OrganizationDTO dto = new OrganizationDTO(org.email, org.name);

                return new AuthenticationResponse(token, dto);
            }
            catch (Exception)
            {
                throw new Exception("Internal error registering a new organization");
            }
        }


        // HELPERS
        private string encrypt(string password, string salt)
        {
            byte[] data = Encoding.ASCII.GetBytes(password + salt);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }

        private string generateJwtToken(Organization org)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JWTSecret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, org.email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}