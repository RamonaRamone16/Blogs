using Microsoft.AspNetCore.Identity;

namespace Blogs.DAL.Entities
{
    public class User : IdentityUser<int>, IEntity
    {
    }
}
