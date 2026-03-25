using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hal_Taalam.ViewModel.Account
{
    public class RegeisterVM
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="conformed password")]
        [Compare("Password")]
        public string conformidPassword { get; set; }
        public string Email { get; set; }

    }
}
