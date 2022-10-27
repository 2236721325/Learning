using System.ComponentModel.DataAnnotations;

namespace Dto_autemapper_redis.Dtos
{
    public class UserDto:BaseEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Account { get; set; }
    }

    public class UserLoginDto 
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
    public class UserRegisteDto
    {
        [MaxLength(2,ErrorMessage ="长度不能超过2" )]//演示使用数据注解形式来验证数据。
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

    }
}
