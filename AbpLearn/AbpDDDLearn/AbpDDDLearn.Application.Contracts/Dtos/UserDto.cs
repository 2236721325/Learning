using Volo.Abp.Application.Dtos;

namespace AbpDDDLearn.Application.Contracts.Dtos
{
    public class UserDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
    }

}
