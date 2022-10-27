using Volo.Abp.Domain.Entities;

namespace Abp从0搭建授权中心.Models
{
    public class UserRole:Entity
    {
        public Guid UserId { get; set; }
        public Guid RoleId  { get; set; }
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public override object[] GetKeys()
        {
            return new object[]
            {
                UserId, RoleId
            };
        }
    }
}
