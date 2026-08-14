using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Day1WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(
    RoleManager<IdentityRole> _roleManager,
    UserManager<Pegawai> _userManager,
    IMapper _mapper,
    ILogger<AccountController> _logger) : ControllerBase
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

    [HttpPost("manage/assign-role")]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleDto assignUserRoleDto)
    {
        // Mencari user berdasarkan email
        var user = await _userManager.FindByEmailAsync(assignUserRoleDto.Email);

        if (user == null)
        {
            return NotFound("User tidak ditemukan");
        }

        var result = await _userManager.AddToRoleAsync(user, assignUserRoleDto.RoleName);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok();
    }

    [HttpPost("register-pegawai")]
    [AllowAnonymous]
    public async Task<ActionResult<Pegawai>> RegisterPegawai(RegisterPegawaiDto registerPegawaiDto)
    {
        var user = _mapper.Map<Pegawai>(registerPegawaiDto);

        var result = await _userManager.CreateAsync(user, registerPegawaiDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return user;
    }

    [HttpGet("manage/info-pegawai")]
    public async Task<ActionResult<PegawaiClaimsDto>> GetInfoPegawai()
    {
        for (int i = 0; i < User.Claims.Count(); i++)
        {
            _logger.LogInformation($"Claim {i}: {User.Claims.ElementAt(i).Type} - {User.Claims.ElementAt(i).Value}");
        }

        var pegawai = new PegawaiClaimsDto
        {
            Id = User.FindFirstValue(ClaimTypes.NameIdentifier),
            Email = User.FindFirstValue(ClaimTypes.Email),
            Nama = User.FindFirstValue("nama"),
            NIP = User.FindFirstValue("nip"),
            Jabatan = User.FindFirstValue("jabatan"),
            TanggalMasuk = User.FindFirstValue("tanggal_masuk"),
            Roles = [.. User.FindAll(ClaimTypes.Role).Select(c => c.Value)]
        };

        return pegawai;
    }
}