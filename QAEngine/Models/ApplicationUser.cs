using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace QAEngine.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        /* Id, UserName, PasswordHash, SecurityStamp derived from IndentityUser base class */
    }
}
