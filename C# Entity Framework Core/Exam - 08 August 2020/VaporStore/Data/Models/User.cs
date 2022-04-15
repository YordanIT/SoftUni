using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
            Cards = new HashSet<Card>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(VaporStoreContextConst.UserNameMaxLenght)]
        public string Username { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(103)]
        public int Age { get; set; }

        public ICollection<Card> Cards { get; set; }

    }
}
