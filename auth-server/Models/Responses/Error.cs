namespace auth_server.Models.Responses
{
    public class Error
    {
        public string type;
        public string message;

        public Error(string p_message)
        {
            this.type = "error";
            this.message = p_message;
        }
    }
}
