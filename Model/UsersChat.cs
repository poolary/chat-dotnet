using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backender.Model
{
    public class UsersChat
    {
        public string UserName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateOnly BirthDate { get; set; }
        [NotMapped]
        public int Age
        {
            get
            {
                var today = DateOnly.FromDateTime(DateTime.Today);
                var age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age)) age--;
                return age;
            }
        }

    }
}
