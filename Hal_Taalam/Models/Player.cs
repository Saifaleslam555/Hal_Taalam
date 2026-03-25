using Hal_Taalam.Models.DBcontext;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hal_Taalam.Models
{
    public class Player
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }
      
        [DefaultValue(0)]
        public double? Score { get; set; }

       
        public int? Age { get; set; }
        [Required]
        //[DefaultValue(0)]
        public int? level { get; set; } 
        
        public string? ImgURL {  get; set; }

        public int xp { get; set; } = 20;

        public int? rank { get; set; }
        public bool? IsPlaying { get; set; }

        //public int xp { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser ApplicationUser { get; set; }


    }
}
