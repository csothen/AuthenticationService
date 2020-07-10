namespace auth_server.Controllers.Commands
{
    public class LoginCommand : ICommand
    {
        public string email;
        public string password;

        public bool Validate()
        {
            return (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password));
        }
    }
}