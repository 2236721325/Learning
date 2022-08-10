using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity框架.Models
{
    public class User:IdentityUser<int>
    {

    }
    public class Role:IdentityRole<int>
    {

    }

    public class MyDbContext:IdentityDbContext
    {
      
        public MyDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
    

}
