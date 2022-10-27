using Volo.Abp.Domain.Entities;

namespace Abp从0搭建授权中心.Models
{
    public class RolePermission:Entity
    {
        public Guid RoleId  { get; set; }
        public Guid PermissionId { get; set; }
        public RolePermission(Guid roleId, Guid permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }

        public override object[] GetKeys()
        {
            return new object[] { RoleId, PermissionId };
        }
    }
}
