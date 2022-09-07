using Volo.Abp.Application.Dtos;

namespace AbpDDDLearn.Application.Contracts.Dtos
{
    public class CreateUserDto : EntityDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
