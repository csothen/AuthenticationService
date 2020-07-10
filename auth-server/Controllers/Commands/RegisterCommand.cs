namespace auth_server.Controllers.Commands
{
    public class RegisterCommand : ICommand
    {
        public string email;
        public string name;
        public string password;

        public bool Validate()
        {
            return (
                string.IsNullOrWhiteSpace(email)
                || string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(password)
                );
        }
    }
}