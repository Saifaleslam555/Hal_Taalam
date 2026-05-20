using System.ComponentModel.DataAnnotations.Schema;

namespace Hal_Taalam.Models
{
    public class GameResults
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public int score { get; set; } = 0;
        public DateTime DatePlayed { get; set; } = DateTime.Now;



        public int playerId { get; set; }
        [ForeignKey("playerId")]

        public Player player { get; set; }
    }
}
