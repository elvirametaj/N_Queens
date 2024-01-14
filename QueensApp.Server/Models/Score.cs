using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueensApp.Server.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }
        public int ScoreAmount { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
