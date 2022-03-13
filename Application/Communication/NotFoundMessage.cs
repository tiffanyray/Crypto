namespace Application.Communication
{
    public class NotFoundMessage
    {
        public string Message { get; set; }

        public NotFoundMessage()
        {
            Message = "Not found";
        }

        public NotFoundMessage(string entityName)
        {
            Message = $"{entityName} not found";
        }
    }
}