using tms.Models;
using Tms.Models;
namespace Tms.Repositories.Abstract{
    public interface IUserAuthenticationService{
        Task<Status> LoginAsync(UserLogin model);
        Task<Status> RegistrationAsync(RegistrationModel model);
        Task LogoutAsync();
    
    }

}