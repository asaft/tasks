using System.ComponentModel.DataAnnotations;

namespace usertasks.Models
{
    

    public class Task:BaseEntity
    {
        
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public int TaskStatus { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}