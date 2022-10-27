using Volo.Abp.Domain.Entities;

namespace Abp从0搭建授权中心.Models
{
    public class User:Entity<Guid>
    {
        public string Name { get; set; }
        public string Acount { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public User(Guid id,string name, string acount, string passwordHash)
        {
            Id = id;
            Name = name;
            Acount = acount;
            PasswordHash = passwordHash;
        }
    }


}
