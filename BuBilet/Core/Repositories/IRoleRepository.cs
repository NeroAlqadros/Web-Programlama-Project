using BuBilet.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace BuBilet.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}