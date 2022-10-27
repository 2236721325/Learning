using Volo.Abp.Domain.Entities;

namespace Abp从0搭建授权中心.Models
{
    public class Role:Entity<Guid>
    {
        public string Name { get; set; }
        public  ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        public Role(Guid id,string name)
        {
            Id = id;
            Name = name;
        }
    }


}
