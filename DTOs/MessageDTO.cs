using System.Text.Json.Serialization;

namespace Backender.DTOs
{
    public class MessageDTO
    {
        public string? Message { get; set; }
        public string? IdSender { get; set; }
        public string? IdReceiver { get; set; }
        [JsonIgnore]public DateTime? Today { get; set; } 
    }
    public class ReaderDTO 
    { 
        public int MyId { get; set; }
        [JsonIgnore] public string Message { get; set; } 
    }
    public class CreateAccountDTO
    {
         public int Id { get; set; }
         public string UserName { get; set; }
         public DateOnly BirthDate { get; set; }

    }
}
