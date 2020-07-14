namespace auth_server.Controllers.Commands
{
    public class RegisterCommand : ICommand
    {
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }

        public bool Validate()
        {
            return !(
                string.IsNullOrWhiteSpace(email)
                || string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(password)
                );
        }
    }
}