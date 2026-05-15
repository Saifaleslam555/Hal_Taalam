using System.ComponentModel.DataAnnotations.Schema;

namespace Hal_Taalam.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
