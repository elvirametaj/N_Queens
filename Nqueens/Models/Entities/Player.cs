using System.ComponentModel.DataAnnotations;

namespace Nqueens.Models.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
