﻿using BuBilet.Areas.Identity.Data;
using BuBilet.Core.Repositories;
using BuBilet.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace ASP.NETCoreIdentityCustom.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}