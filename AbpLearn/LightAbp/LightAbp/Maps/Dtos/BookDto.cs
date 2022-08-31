using LightAbp.Models;
using Volo.Abp.Application.Dtos;

namespace LightAbp.Maps.Dtos
{
    public class BookDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}
