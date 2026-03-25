using Hal_Taalam.ViewModel.Account;
using Microsoft.AspNetCore.Identity;

namespace Hal_Taalam.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<IdentityResult>Register(RegeisterVM regeisterVM);

        Task<SignInResult>Login(LoginVM loginVM);

        Task SignOut();
    }
}
