using Volo.Abp.Domain.Entities;

namespace Abp从0搭建授权中心.Models
{
    public class Permission:Entity<Guid>
    {
        public string Name { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        public Permission(Guid id,string name)
        {
            Id= id;
            Name = name;
        }
    }


}
