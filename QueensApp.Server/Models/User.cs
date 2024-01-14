using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueensApp.Server.Models
{
    public class Player
    {
        [Key]
        public int Id { get;set; }

        [Required]
        public string Username { get; set; }

        public DateTime TimeCreate { get; set; }

        public Score Score { get; set; }

    }
}
