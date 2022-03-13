namespace Application.Communication
{
    public class ErrorMessage
    {
        public string Message { get; set; }
        
        public ErrorMessage()
        {
            Message = "An error occured";
        }

        public ErrorMessage(string action)
        {
            Message = $"An error occured when {action}";
        }

        public ErrorMessage(string action, string entityName)
        {
            Message = $"An error occured when {action} the {entityName}";
        }

        public ErrorMessage(string action, string entityName, string message)
        {
            Message = $"An error occured when {action} the {entityName}: {message}";
        }
    }
}