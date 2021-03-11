using System.ComponentModel.DataAnnotations;

namespace usertasks.Models
{
    public class User:BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        [MaxLength(25)]
        public string UserName { get; set; }
        [MaxLength(25)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}