using Microsoft.AspNetCore.Identity;

namespace Day1WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(RoleManager<IdentityRole> _roleManager) : ControllerBase
{
    [HttpPost("role")]
    public async Task<ActionResult<IdentityRole>> CreateRole(CreateRoleDto createRoleDto)
    {
        var role = new IdentityRole(createRoleDto.RoleName);

        var result = await _roleManager.CreateAsync(role);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return role;
    }
}