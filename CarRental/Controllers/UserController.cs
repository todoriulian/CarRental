using System.Security.Claims;
using CarRental.Domain.Common.Enums;
using CarRental.Domain.Entities;
using CarRental.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRole.Admin)]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users = await _dbContext.ApplicationUsers
                .Where(u => !u.IsDeleted)
                .Select(u => new UserDto
                {
                    Guid = u.Guid,
                    GoogleSubjectId = u.GoogleSubjectId,
                    Email = u.Email,
                    Role = u.Role
                })
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("me")]
        [AllowAnonymous]
        [Authorize]
        public IActionResult GetMySubjectId()
        {
            var sub = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                   ?? User.FindFirst("sub")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value
                     ?? User.FindFirst("email")?.Value;

            return Ok(new { GoogleSubjectId = sub, Email = email });
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [Authorize]
        public async Task<ActionResult<UserDto>> RegisterSelf()
        {
            var sub = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                   ?? User.FindFirst("sub")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value
                     ?? User.FindFirst("email")?.Value;

            if (string.IsNullOrEmpty(sub))
                return BadRequest("Could not determine Google Subject ID from token.");

            var existing = await _dbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.GoogleSubjectId == sub && !u.IsDeleted);

            if (existing != null)
                return Ok(new UserDto
                {
                    Guid = existing.Guid,
                    GoogleSubjectId = existing.GoogleSubjectId,
                    Email = existing.Email,
                    Role = existing.Role
                });

            // First user ever gets Admin role, others get Client
            var hasAnyUsers = await _dbContext.ApplicationUsers.AnyAsync(u => !u.IsDeleted);
            var role = hasAnyUsers ? UserRole.Client : UserRole.Admin;

            var user = new ApplicationUser
            {
                Guid = Guid.NewGuid(),
                GoogleSubjectId = sub,
                Email = email ?? "",
                Role = role
            };

            _dbContext.ApplicationUsers.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Guid }, new UserDto
            {
                Guid = user.Guid,
                GoogleSubjectId = user.GoogleSubjectId,
                Email = user.Email,
                Role = user.Role
            });
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserRequest request)
        {
            if (!IsValidRole(request.Role))
                return BadRequest($"Invalid role. Valid roles: {UserRole.Admin}, {UserRole.Client}, {UserRole.Dispatcher}");

            var existing = await _dbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.GoogleSubjectId == request.GoogleSubjectId && !u.IsDeleted);

            if (existing != null)
                return Conflict("A user with this Google Subject ID already exists.");

            var user = new ApplicationUser
            {
                Guid = Guid.NewGuid(),
                GoogleSubjectId = request.GoogleSubjectId,
                Email = request.Email,
                Role = request.Role
            };

            _dbContext.ApplicationUsers.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Guid }, new UserDto
            {
                Guid = user.Guid,
                GoogleSubjectId = user.GoogleSubjectId,
                Email = user.Email,
                Role = user.Role
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid id)
        {
            var user = await _dbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Guid == id && !u.IsDeleted);

            if (user == null)
                return NotFound();

            return Ok(new UserDto
            {
                Guid = user.Guid,
                GoogleSubjectId = user.GoogleSubjectId,
                Email = user.Email,
                Role = user.Role
            });
        }

        [HttpPut("{id}/role")]
        public async Task<ActionResult<UserDto>> UpdateUserRole(Guid id, UpdateUserRoleRequest request)
        {
            if (!IsValidRole(request.Role))
                return BadRequest($"Invalid role. Valid roles: {UserRole.Admin}, {UserRole.Client}, {UserRole.Dispatcher}");

            var user = await _dbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Guid == id && !u.IsDeleted);

            if (user == null)
                return NotFound();

            user.Role = request.Role;
            await _dbContext.SaveChangesAsync();

            return Ok(new UserDto
            {
                Guid = user.Guid,
                GoogleSubjectId = user.GoogleSubjectId,
                Email = user.Email,
                Role = user.Role
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _dbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Guid == id && !u.IsDeleted);

            if (user == null)
                return NotFound();

            _dbContext.ApplicationUsers.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private static bool IsValidRole(string role)
        {
            return role == UserRole.Admin
                || role == UserRole.Client
                || role == UserRole.Dispatcher;
        }
    }

    public class CreateUserRequest
    {
        public string GoogleSubjectId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

    public class UpdateUserRoleRequest
    {
        public string Role { get; set; } = null!;
    }

    public class UserDto
    {
        public Guid Guid { get; set; }
        public string GoogleSubjectId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
