using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app.Models.Security
{
    public class AppUser: IdentityUser
    {
        public bool IsBusinessUser { get; set; }
    }
}
