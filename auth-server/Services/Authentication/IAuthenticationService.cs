using System.Threading.Tasks;
using auth_server.Controllers.Commands;
using auth_server.Models.Authentication;

namespace auth_server.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> login(LoginCommand command);
        Task<AuthenticationResponse> register(RegisterCommand command);
    }
}