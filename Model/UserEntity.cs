using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Backender.Model
{
    public class UserEntity
    {
    
        /*public UserEntity(string name, string message, int idSender, int idReceiver)
        {
          Name_Message = name;
          Message = message;
          IdSender = idSender;
          IdReceiver = idReceiver;
          CreatedAt = DateTime.UtcNow;
        }*/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        public string Name_Message{ get; set;} = string.Empty;
        public string Message { get; set; }
        public string Message_Receiver { get; set; } = string.Empty;
        public int IdSender { get; set; }
        public int IdReceiver { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
