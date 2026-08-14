using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Day1WebApi.ClaimsPrincipalFactory;

public class PegawaiClaimsPrincipalFactory(UserManager<Pegawai> userManager,
    IOptions<IdentityOptions> optionsAccessor)
        : UserClaimsPrincipalFactory<Pegawai>(userManager, optionsAccessor)
{
    public override async Task<ClaimsPrincipal> CreateAsync(Pegawai user)
    {
        var principal = await base.CreateAsync(user);

        var identity = principal.Identity as ClaimsIdentity;

        identity?.AddClaim(new Claim("nama", user.Nama));
        identity?.AddClaim(new Claim("nip", user.NIP));
        identity?.AddClaim(new Claim("jabatan", user.Jabatan));
        identity?.AddClaim(new Claim("tanggal_masuk", user.TanggalMasuk.ToString("yyyy-MM-dd")));

        var roles = await UserManager.GetRolesAsync(user);

        foreach (var role in roles)
        {
            identity?.AddClaim(new Claim(ClaimTypes.Role, role));
        }

        return principal;
    }
}