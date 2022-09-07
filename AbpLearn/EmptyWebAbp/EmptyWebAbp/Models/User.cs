using EmptyWebAbp.Shared;
using Volo.Abp.Domain.Entities;

namespace EmptyWebAbp.Models
{
    public class User:BasicAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public void CreateGuid(Guid id)
        {
            if(Id!=Guid.Empty)
            {
                throw new Exception("实体Guid已存在，不可改变");
            }
            Id = id;
        }
        public void ChangePassword(string newpassword)
        {
            var old = Password;
            Password = newpassword;
            AddLocalEvent(
               new UserPasswordChangedEvent(old,newpassword)
           );
            AddDistributedEvent(
                new UserPasswordChangedEvent(old, newpassword)
                );
        }
        
    }
}
