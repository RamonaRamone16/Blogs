using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.DAL.Entities
{
    public class Role : IdentityRole<int>, IEntity
    {
    }
}
