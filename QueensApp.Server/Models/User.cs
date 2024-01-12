using System.ComponentModel.DataAnnotations;

namespace QueensApp.Server.Models
{
    public class User
    {
        [Key]
        public int Id { get;set; }

        [Required]
        public string Username { get; set; }

        public DateTime TimeCreate { get; set; }

        public Score Score { get; set; }

    }
}
