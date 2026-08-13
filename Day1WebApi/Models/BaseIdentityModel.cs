using Microsoft.AspNetCore.Identity;

namespace Day1WebApi.Models
{
    public class BaseIdentityModel : IdentityUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
