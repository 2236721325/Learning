using Volo.Abp.Domain.Entities;

namespace EmptyWebAbp.Models
{
    public class Book:BasicAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
