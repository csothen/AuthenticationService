namespace auth_server.Models.Responses
{
    public class Success
    {
        public string type;
        public string message;

        public Success(string p_message)
        {
            this.type = "success";
            this.message = p_message;
        }
    }
}