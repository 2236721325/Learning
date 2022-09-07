using Volo.Abp.Application.Dtos;

namespace AbpDDDLearn.Application.Contracts.Dtos
{
    public class UpdateUserDto : EntityDto<Guid>
    {
        public string Password { get; set; }
    }

}
