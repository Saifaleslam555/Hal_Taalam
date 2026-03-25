using System.ComponentModel.DataAnnotations;

namespace Hal_Taalam.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string question { get; set; }
        
        [Required]
        public int Level { get; set; }

        [Required]
        public string Answer1 { get; set; }
        [Required]
        public string Answer2 { get; set; }
        [Required]
        public string Answer3 { get; set; }
        [Required]
        public string Answer4 { get; set; }

        [Required]
        public int CorrectAnswer { get; set; }
    }
}
