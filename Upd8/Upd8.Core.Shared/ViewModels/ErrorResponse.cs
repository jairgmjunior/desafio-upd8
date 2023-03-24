namespace Upd8.Core.Shared.ViewModels
{
    public class ErrorResponse
    {
        public ErrorResponse(string? id)
        {
            Id = id;
            Date = DateTime.Now;
            Message = "erro inesperado";
        }

        public string Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Message { get; private set; }
    }
}
