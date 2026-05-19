using Hal_Taalam.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hal_Taalam.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string question { get; set; }
        
        [Required]
        public QuestionLevel Level { get; set; }

        [Required]
        public string Answer1 { get; set; } = string.Empty;
        [Required]
        public string Answer2 { get; set; }=string.Empty;
        [Required]
        public string Answer3 { get; set; }= string.Empty;
        [Required]
        public string Answer4 { get; set; } = string.Empty;

        [Required]
        public CorrectAnswerOption CorrectAnswer { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category? Category { get; set; } = null;
    }
}
