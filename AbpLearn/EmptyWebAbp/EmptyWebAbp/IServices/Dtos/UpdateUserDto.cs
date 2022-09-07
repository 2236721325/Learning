using Volo.Abp.Application.Dtos;

namespace EmptyWebAbp.IServices.Dtos
{
    public class UpdateUserDto:EntityDto<Guid>
    {
        public string Password { get; set; }
    }

}
