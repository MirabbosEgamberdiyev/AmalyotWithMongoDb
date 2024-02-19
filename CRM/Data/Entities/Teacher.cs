using System.ComponentModel.DataAnnotations;

namespace CRM.Data.Entities
{
    public class Teacher : BaseEntity
    {

        [Required, StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string PhoneNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public List<string> FanIds { get; set; } = new();
    }
}
