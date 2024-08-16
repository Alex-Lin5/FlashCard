using System.ComponentModel.DataAnnotations;

namespace FlashCardDotNet.Entities
{
    public class User
    {
        [Key]
        public Guid userId { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string username { get; set; }

        public User() { }
    }
}
