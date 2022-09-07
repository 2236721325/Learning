using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace EmptyWebAbp.IServices.Dtos
{
    public class CreateUserDto:EntityDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
