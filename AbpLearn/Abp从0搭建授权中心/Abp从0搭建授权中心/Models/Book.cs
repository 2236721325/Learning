using Volo.Abp.Domain.Entities;

namespace Abp从0搭建授权中心.Models
{
    public class Book:Entity<Guid>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public Book(Guid id,string name, Guid userId)
        {
            Id = id;
            Name = name;
            UserId = userId;
        }

    }


}
