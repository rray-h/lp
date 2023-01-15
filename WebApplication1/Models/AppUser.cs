using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class AppUser: IdentityUser
    {
        public bool? Banned { get; set; }
        public ICollection<Query>? Queries { get; set; }
        
    }
}
