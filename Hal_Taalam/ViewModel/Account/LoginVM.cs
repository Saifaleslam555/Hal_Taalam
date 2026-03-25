using System.ComponentModel.DataAnnotations;

namespace Hal_Taalam.ViewModel.Account
{
    public class LoginVM
    {
        
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Remeberme { get; set; }
    }
}
