using Volo.Abp.Domain.Entities;

namespace AbpDDDLearn.Domain.Models
{
    public class Book : BasicAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
