namespace auth_server.Controllers.Commands
{
    public interface ICommand
    {
        bool Validate();
    }

}