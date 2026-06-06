using System.Security.Claims;
using CarRental.Domain.Common.Enums;
using CarRental.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Services
{
    public class RoleClaimsTransformation : IClaimsTransformation
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleClaimsTransformation(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = principal.Identity as ClaimsIdentity;
            if (identity == null || !identity.IsAuthenticated)
                return principal;

            var googleSubjectId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                ?? identity.FindFirst("sub")?.Value;

            if (string.IsNullOrEmpty(googleSubjectId))
                return principal;

            // Avoid adding duplicate role claims on repeated calls
            if (identity.HasClaim(c => c.Type == ClaimTypes.Role))
                return principal;

            var user = await _dbContext.ApplicationUsers
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.GoogleSubjectId == googleSubjectId && !u.IsDeleted);

            if (user != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
            }

            return principal;
        }
    }
}
