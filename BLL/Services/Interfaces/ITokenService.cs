using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, List<IdentityRole<long>> role);
    }
}
