namespace auth_server.Controllers.Commands
{
    public class LoginCommand : ICommand
    {
        public string email { get; set; }
        public string password { get; set; }

        public bool Validate()
        {
            return !(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password));
        }
    }
}